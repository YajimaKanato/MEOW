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
    Queue<Paragraph> _queue;
    InteractStateMachine _stateMachine = new();
    bool _subscribed;
    bool _runningStreamingText;
    bool _gaveItem;
    bool _openMenu;

    public InteractPresenter(InteractView view, InteractModel model)
    {
        _view = view;
        _runtime = model.CreateRuntime();
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
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }

    void StartInteract(StartInteractToken token)
    {
        if (_runtime.SetTalker(token.CharacterType, out _currentConversation))
        {
            UpdateInteract();
            ChangeState();
        }
    }

    public void ChangeState()
    {
        var paragraph = _queue.Peek();
        IEnterState state = null;
        switch (paragraph.NodeType)
        {
            case NodeType.Conversation:
                state = new ConversationEnter(this);
                break;
            case NodeType.Choice:
                break;
            case NodeType.GiveItem:
                break;
            default:
                break;
        }
        _stateMachine.ChangeState(state);
    }

    void UpdateInteract()
    {
        if (_currentConversation == null) return;
        //テキストがないまたは既にテキストを流し終わった後
        if (_currentConversation.Texts == null || _currentConversation.Texts.Length <= 0 || (_queue != null && _queue.Count <= 0))
        {
            ////アイテムを渡すインタラクトの場合はUIだけ表示
            //if (_currentConversation.NodeType == NodeType.GiveItem)
            //{
            //    EventBus.Publish(new GiveItemToken(_currentConversation.Item));
            //    return;
            //}
            //自動分岐判定
            foreach (var conversation in _currentConversation.Branches)
            {
                if (_runtime.CheckCondition(conversation))
                {
                    _currentConversation = conversation.Next;
                    break;
                }
            }
            _currentConversation = _currentConversation.Default;
        }
        _queue = new();
        foreach (var text in _currentConversation.Texts)
        {
            _queue.Enqueue(text);
        }
    }

    public void StreamText()
    {
        var talk = _queue.Dequeue();
        _view?.OpenInteractWindow();
        _view?.StartStreamText(StreamText(talk.Text));
        _view?.SetTalkers(talk.LeftTalker, talk.RightTalker);
        switch (talk.TalkerType)
        {
            case CurrentTalker.Left:
                _view?.TalkLeft(talk.LeftTalker);
                break;
            case CurrentTalker.Right:
                _view?.TalkRight(talk.RightTalker);
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
            if (_queue == null || _queue.Count <= 0)
            {
                if (_currentConversation != null && _currentConversation.Finish)
                    FinishInteract();
            }
            else
            {
                _stateMachine.Execute();
            }
        }
        else
        {
            _runningStreamingText = false;
        }
    }

    void FinishInteract()
    {
        if (_currentConversation == null)
        {
            _view?.CloseInteractWindow();
            _queue = null;
            EventBus.Publish(new BackActionMapToken());
            return;
        }
        _runtime.UpdateID(_currentConversation.CharacterType, _currentConversation.Default.ID);
        if (_currentConversation.Finish)
        {
            _view?.CloseInteractWindow();
            _queue = null;
            _currentConversation = _currentConversation.Default;
            EventBus.Publish(new BackActionMapToken());
        }
        else
        {
            UpdateInteract();
        }
    }

    void SetKey(SetFlagToken token)
    {
        _runtime.SetKey(token.Key);
    }

    void RemoveKey(RemoveFlagToken token)
    {
        _runtime.RemoveKey(token.Key);
    }

    //void GiveItem()
    //{
    //    var item = _currentConversation.Item;
    //}

    void OpenHotbar()
    {
        _runtime.OpenHotbar();
        //_view?.OpenHotbar();
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

    void CloseHotbar()
    {
        _view?.CloseHotbar();
    }
}