using MVPTools.Runtime;
using UnityEngine;

public class ActionMapPresenter : ISubscribable
{
    ActionMapView _view;
    ActionMapRuntime _runtime;
    bool _subscribed;

    public ActionMapPresenter(ActionMapView view, ActionMapModel model)
    {
        _view = view;
        _runtime = model.CreateRuntime();
        NextActionMap(new NextActionMapToken(ActionMap.None));
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
        EventBus.Subscribe<NextActionMapToken>(this, NextActionMap);
        EventBus.Subscribe<BackActionMapToken>(this, PreActionMap);
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }

    void NextActionMap(NextActionMapToken token)
    {
        if (_runtime == null) return;
        var actionMap = token.ActionMap;
        actionMap = _runtime.NextActionMap(actionMap);
        _view?.ChangeActionMap(actionMap);
    }

    void PreActionMap(BackActionMapToken _)
    {
        if (_runtime == null) return;
        var actionMap = _runtime.GetPreActionMap();
        _view?.ChangeActionMap(actionMap);
    }
}