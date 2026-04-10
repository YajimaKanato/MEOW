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
        EventBus.Subscribe<StartStreamTextToken>(this, StartStreamText);
        EventBus.Subscribe<PushEnterOnInteractToken>(this, PushEnter);
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }

    void StartStreamText(StartStreamTextToken token)
    {
        if (_runtime == null) return;
        if (_runningStreamingText) return;
        _view?.StartStreamText(StreamText(_runtime.GetText(token.CharacterType)));
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
        if (_runningStreamingText)
        {
            _runningStreamingText = false;
        }
        else
        {
            //次の会話
        }
    }
}