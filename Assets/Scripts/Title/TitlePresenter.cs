using MVPTools.Runtime;
using UnityEngine;

public class TitlePresenter : ISubscribable
{
    TitleView _view;
    TitleRuntime _runtime;
    bool _subscribed;

    public TitlePresenter(TitleView view, TitleModel model)
    {
        _view = view;
        _runtime = new TitleRuntime(model);
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
        //EventBus.Subscribe<>(this,);
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }
}