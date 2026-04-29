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
    ConversationState _conversation;
    GiveItemState _giveItem;
    ChoiceState _choice;
    SelectState _select;
    SceneTransitionState _sceneTransition;
    FinishState _finish;
    InteractStateMachine _stateMachine = new();
    string _currentInteractor;
    bool _subscribed;
    bool _runningStreamingText;
    bool _gaveItem;
    bool _openMenu;

    public ConversationAsset CurrentConversation => _currentConversation;
    public Paragraph CurrentParagraph => _currentParagraph;
    public string CurrentInteractor => _currentInteractor;

    public InteractPresenter(InteractView view, InteractModel model)
    {
        _view = view;
        if (!RuntimeStorage.TryGetData<InteractRuntime>(view.ID, out var data))
        {
            _runtime = new InteractRuntime(model);
            RuntimeStorage.RegisterData(view.ID, _runtime);
        }
        else
        {
            _runtime = data;
        }
        _conversation = new ConversationState(_view, this, _runtime);
        _giveItem = new GiveItemState(_view, this, _runtime);
        _choice = new ChoiceState(_view, this, _runtime);
        _select = new SelectState(_view, this, _runtime);
        _sceneTransition = new SceneTransitionState(_view, this, _runtime);
        _finish = new FinishState(_view, this, _runtime);
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
        EventBus.Subscribe<SelectInteractToken>(this, SelectIndex);
        EventBus.Subscribe<MoveInteractToken>(this, MoveIndex);
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
        _view?.ActivateBack();
    }

    public void ChangeState()
    {
        IInteractState state = _finish;
        if (_queue.TryDequeue(out _currentParagraph))
        {
            switch (_currentParagraph.NodeType)
            {
                case NodeType.Conversation:
                    state = _conversation;
                    break;
                case NodeType.Choice:
                    state = _choice;
                    break;
                case NodeType.ItemSelect:
                    state = _select;
                    break;
                case NodeType.GiveItem:
                    state = _giveItem;
                    break;
                case NodeType.SceneTransition:
                    state = _sceneTransition;
                    break;
                default:
                    break;
            }
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

    public IEnumerator StreamText(string text)
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
            _stateMachine.PushEnter();
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
            NextConversation(_currentConversation.Default);
            _view?.CloseInteractWindow();
            EventBus.Publish(new BackActionMapToken());
        }
        else
        {
            //自動分岐判定
            var nextBranch = false;
            foreach (var conversation in _currentConversation.Branches)
            {
                if (_runtime.CheckCondition(conversation))
                {
                    NextConversation(conversation.Next);
                    nextBranch = true;
#if UNITY_EDITOR
                    Debug.Log("Condition Completed");
#endif
                    break;
                }
                else
                {
                    Debug.Log(conversation);
                }
            }
            if (!nextBranch) NextConversation(_currentConversation.Default);
            UpdateInteract();
            ChangeState();
        }
        _runtime.UpdateID(_currentConversation.CharacterType, _currentConversation.ID);
        Debug.Log($"{_currentConversation.CharacterType} {_currentConversation.ID}");
    }

    public void NextConversation(ConversationAsset asset)
    {
        if (asset == null) return;
        _currentConversation = asset;
#if UNITY_EDITOR
        Debug.Log(_currentConversation);
#endif
    }

    void SetKey(SetFlagToken token)
    {
        if (_runtime.SetKey(token.Key))
#if UNITY_EDITOR
            Debug.Log($"Condition \"{token.Key}\" Completed");
#endif
    }

    void RemoveKey(RemoveFlagToken token)
    {
        _runtime.RemoveKey(token.Key);
#if UNITY_EDITOR
        Debug.Log($"Condition \"{token.Key}\" Removed");
#endif
    }

    void SelectIndex(SelectInteractToken token)
    {
        _stateMachine?.SelectIndex(token.Index);
    }

    void MoveIndex(MoveInteractToken token)
    {
        _stateMachine?.MoveIndex(token.Move);
    }
}