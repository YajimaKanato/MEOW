using MVPTools.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InteractPresenter : ISubscribable
{
    InteractView _view;
    InteractRuntime _runtime;
    ConversationAsset _currentConversation;
    Queue<Paragraph> _queue = new();
    Paragraph _currentParagraph;
    InteractStateMachine _stateMachine = new();
    string _currentInteractor;
    bool _subscribed;
    bool _runningStreamingText;
    bool _gaveItem;
    bool _openMenu;

    public InteractPresenter(InteractView view, InteractModel model)
    {
        _view = view;
        _runtime = new InteractRuntime(model);
        if (_runtime == null) throw new System.NullReferenceException(nameof(_runtime));
    }

    public void Dispose()
    {
        _runtime?.Dispose();
        _runtime = null;
        Unsubscribe();
    }

    public void Subscribe()
    {
        if (_subscribed) return;
        _subscribed = true;
        EventBus.Subscribe<PushEnterOnInteractToken>(this, PushEnter);
        EventBus.Subscribe<StartInteractToken>(this, StartInteract);
        EventBus.Subscribe<SetFlagToken>(this, SetKey);
        EventBus.Subscribe<RemoveFlagToken>(this, RemoveKey);
        EventBus.Subscribe<SelectInteractHotbarToken>(this, SelectSlot);
        EventBus.Subscribe<MoveInteractHotbarToken>(this, MoveIndex);
        EventBus.Subscribe<GetItemToken>(this, UpdateHotbar);
        EventBus.Subscribe<UseItemToken>(this, UpdateHotbar);
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }

    void StartInteract(StartInteractToken token)
    {
        _currentInteractor = token.ID;
        if (_runtime.SetTalker(token.CharacterType, out _currentConversation))
        {
            UpdateInteract();
        }
        ChangeState();
    }

    public void ChangeState()
    {
        if (!_queue.TryDequeue(out _currentParagraph))
        {
            FinishInteract();
            return;
        }
        IEnterState state = null;
        switch (_currentParagraph.NodeType)
        {
            case NodeType.Conversation:
                state = new ConversationEnter(this);
                break;
            case NodeType.Choice:
                break;
            case NodeType.GiveItem:
                state = new GiveItemEnter(this);
                break;
            default:
                break;
        }
        _stateMachine.ChangeState(state);
    }

    void UpdateInteract()
    {
        foreach (var text in _currentConversation.Texts)
        {
            _queue.Enqueue(text);
        }
    }

    public void StreamText()
    {
        _view?.OpenInteractWindow();
        _view?.StartStreamText(StreamText(_currentParagraph.Text));
        _view?.SetTalkers(_currentParagraph.LeftTalker, _currentParagraph.RightTalker);
        switch (_currentParagraph.TalkerType)
        {
            case CurrentTalker.Left:
                _view?.TalkLeft(_currentParagraph.LeftTalker);
                break;
            case CurrentTalker.Right:
                _view?.TalkRight(_currentParagraph.RightTalker);
                break;
            case CurrentTalker.Narration:
                _view?.TalkNarration();
                break;
        }
    }

    IEnumerator StreamText(string text)
    {
        _runningStreamingText = true;
        var sb = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            //待機ループ
            while (_openMenu)
            {
                yield return null;
            }
            sb.Append(text[i]);
            _view?.StreamText(sb.ToString());
            if (!_runningStreamingText) break;
            var waitTime = 1f / (int)_runtime.CurrentTextSpeed;
            var t = 0f;
            while (t < waitTime)
            {
                if (!_runningStreamingText) break;
                if (!_openMenu)
                    t += Time.deltaTime;
                yield return null;
            }
        }
        _view?.StreamText(text);
        _runningStreamingText = false;
    }

    void PushEnter(PushEnterOnInteractToken token)
    {
        if (!_runningStreamingText)
        {
            _stateMachine.Execute();
        }
        else
        {
            _runningStreamingText = false;
        }
    }

    public void FinishInteract()
    {
        if (_currentConversation == null)
        {
            _view?.CloseInteractWindow();
            EventBus.Publish(new BackActionMapToken());
            return;
        }

        if (_currentConversation.Finish)
        {
            _view?.CloseInteractWindow();
            EventBus.Publish(new BackActionMapToken());
            _currentConversation = _currentConversation.Default;
        }
        else
        {
            //自動分岐判定
            var nextBranch = false;
            foreach (var conversation in _currentConversation.Branches)
            {
                if (_runtime.CheckCondition(conversation))
                {
                    _currentConversation = conversation.Next;
                    nextBranch = true;
                    break;
                }
            }
            if (!nextBranch) _currentConversation = _currentConversation.Default;
            UpdateInteract();
            ChangeState();
        }
        _runtime.UpdateID(_currentConversation.CharacterType, _currentConversation.ID);
    }

    void SetKey(SetFlagToken token)
    {
        _runtime.SetKey(token.Key);
    }

    void RemoveKey(RemoveFlagToken token)
    {
        _runtime.RemoveKey(token.Key);
    }

    public void GiveItem()
    {
        if (!RuntimeStorage.TryGetData(_currentInteractor, out var data) || !(data is InteractableRuntime typed)) return;
        var item = typed.Item;
        _view?.GetItem(item);
    }

    void UpdateHotbar(GetItemToken token)
    {
        if (RuntimeStorage.TryGetData(token.ID, out var data) && data is PlayerRuntime typed)
            _runtime.UpdateHotbar(typed.Hotbar);
    }

    void UpdateHotbar(UseItemToken token)
    {
        if (RuntimeStorage.TryGetData(token.ID, out var data) && data is PlayerRuntime typed)
            _runtime.UpdateHotbar(typed.Hotbar);
    }

    public void OpenHotbar()
    {
        if (!RuntimeStorage.TryGetData(_currentInteractor, out var data) || data is not InteractableRuntime typed) return;
        var item = typed.Item;
        if (_runtime.GetItem(item))
        {
            _view?.CloseGetItemWindow();
            ChangeState();
            EventBus.Publish(new DropItemToken(_currentInteractor, _runtime.Hotbar[_runtime.Hotbar.Length - 1]));
            EventBus.Publish(new GiveItemToken(_runtime.Hotbar));
            return;
        }
        _runtime.OpenHotbar();
        _view?.OpenHotbar(_runtime.Hotbar, item);
        _stateMachine?.ChangeState(new ChangeItemEnter(this));
    }

    void SelectSlot(SelectInteractHotbarToken token)
    {
        var index = _runtime.SelectIndex(token.Index);
        _view?.ChangeSlot(index);
    }

    void MoveIndex(MoveInteractHotbarToken token)
    {
        var index = _runtime.MoveIndex(token.Move);
        _view?.ChangeSlot(index);
    }

    public void CloseHotbar()
    {
        _runtime.ChangeItem();
        EventBus.Publish(new DropItemToken(_currentInteractor, _runtime.Hotbar[_runtime.Hotbar.Length - 1]));
        EventBus.Publish(new GiveItemToken(_runtime.Hotbar));
        _view?.CloseHotbar();
        ChangeState();
    }
}