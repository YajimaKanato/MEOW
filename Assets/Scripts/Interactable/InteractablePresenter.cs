using MVPTools.Runtime;
using UnityEngine;

public class InteractablePresenter : ISubscribable
{
    protected InteractableView _view;
    protected InteractableRuntime _runtime;
    bool _subscribed;

    public InteractablePresenter(InteractableView view, InteractableModel model)
    {
        _view = view;
        if (!RuntimeStorage.TryGetData<InteractableRuntime>(view.ID, out var data))
        {
            _runtime = new InteractableRuntime(model);
            RuntimeStorage.RegisterData(view.ID, _runtime);
        }
        else
        {
            _runtime = data;
        }
    }

    public void Dispose()
    {
        _runtime?.Dispose();
        _runtime = null;
        Unsubscribe();
    }

    public virtual void Subscribe()
    {
        if (_subscribed) return;
        _subscribed = true;
        EventBus.Subscribe<DropItemToken>(this, DropItem);
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }

    public void Interact()
    {
        var character = _runtime.CharacterType;
        EventBus.Publish(new StartInteractToken(_view.ID, character));
    }

    void DropItem(DropItemToken token)
    {
        if (token.ID != _view.ID) return;
        _view?.DropItem(token.Item);
    }
}