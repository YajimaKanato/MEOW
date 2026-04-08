using MVPTools.Runtime;
using UnityEngine;

public class PlayerInteractPresenter : ISubscribable
{
    PlayerInteractView _view;
    PlayerInteractRuntime _runtime;
    bool _subscribed;

    public PlayerInteractPresenter(PlayerInteractView view, PlayerInteractModel model)
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
        //EventBus.Subscribe<>(this,);
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }
}