using MVPTools.Runtime;
using UnityEngine;

public class HotbarPresenter : ISubscribable
{
    HotbarView _view;
    HotbarRuntime _runtime;
    bool _subscribed;

    public HotbarPresenter(HotbarView view, HotbarModel model)
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
        EventBus.Subscribe<SelectIngameHotbarToken>(this, SelectIngameSlot);
        EventBus.Subscribe<MoveIngameHotbarToken>(this, MoveIngameIndex);
        EventBus.Subscribe<GetItemToken>(this, UpdateHotbar);
        EventBus.Subscribe<UseItemToken>(this, UpdateHotbar);
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }

    public void SelectIngameSlot(SelectIngameHotbarToken token)
    {
        var index = _runtime.SelectIndex(token.Index);
        _view?.ChangeSlot(index);
    }

    public void MoveIngameIndex(MoveIngameHotbarToken token)
    {
        var index = _runtime.MoveIndex(token.Move);
        _view?.ChangeSlot(index);
    }

    void UpdateHotbar(GetItemToken token)
    {
        _runtime.UpdateHotbar(token.Hotbar);
        _view?.UpdateIngameHotbar(_runtime.Hotbar, _runtime.CurrentIndex);
    }

    void UpdateHotbar(UseItemToken token)
    {
        _runtime.UpdateHotbar(token.Hotbar);
        _view?.UpdateIngameHotbar(_runtime.Hotbar, _runtime.CurrentIndex);
    }
}