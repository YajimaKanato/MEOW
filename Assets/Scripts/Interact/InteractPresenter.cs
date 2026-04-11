using MVPTools.Runtime;
using System.Collections;
using System.Text;
using UnityEngine;

public class InteractPresenter : ISubscribable
{
    InteractView _view;
    InteractRuntime _runtime;
    bool _subscribed;
    bool _runningStreamingText;

    public InteractPresenter(InteractView view, InteractModel model)
    {
        _view = view;
        _runtime = model.CreateRuntime();
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
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }

    void StartInteract(StartInteractToken token)
    {
        _view?.OpenInteractWindow();
        var talker = _runtime.SetTalker(token.CharacterType);
        _view?.SetTalkers(talker.left, talker.right);
        StartStreamText();
    }

    void StartStreamText()
    {
        if (_runtime == null) return;
        var talk = _runtime.GetText();
        _view?.StartStreamText(StreamText(talk.text));
        switch (talk.position)
        {
            case CurrentTalker.Left:
                _view?.TalkLeft(talk.talker);
                break;
            case CurrentTalker.Right:
                _view?.TalkRight(talk.talker);
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
        foreach (var c in text)
        {
            sb.Append(c);
            _view?.StreamText(sb.ToString());
            if (!_runningStreamingText) break;
            yield return new WaitForSeconds(1f / (int)_runtime.CurrentTextSpeed);
        }
        _view?.StreamText(text);
        _runningStreamingText = false;
    }

    void PushEnter(PushEnterOnInteractToken token)
    {
        if (!_runningStreamingText)
        {
            if (!_runtime.ContinueStory)
            {
                FinishInteract();
            }
            else
            {
                StartStreamText();
            }
        }
        else
        {
            _runningStreamingText = false;
        }
    }

    void FinishInteract()
    {
        _view?.CloseInteractWindow();
        EventBus.Publish(new BackActionMapToken());
    }
}