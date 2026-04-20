using MVPTools.Runtime;
using UnityEngine;

public class MenuPresenter : ISubscribable
{
    MenuView _view;
    MenuRuntime _runtime;
    bool _subscribed;

    public MenuPresenter(MenuView view, MenuModel model)
    {
        _view = view;
        _runtime = new MenuRuntime(model);
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