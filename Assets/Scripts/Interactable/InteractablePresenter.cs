using MVPTools.Runtime;
using UnityEngine;

public class InteractablePresenter : ISubscribable
{
    InteractableView _view;
    InteractableRuntime _runtime;
    bool _subscribed;

    public InteractablePresenter(InteractableView view, InteractableModel model)
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

    public void Interact()
    {
        if (_runtime == null) return;
        var character = _runtime.CharacterType;
        //EventBus.Publish(new);
    }
}