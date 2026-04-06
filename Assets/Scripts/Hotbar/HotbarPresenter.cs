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

    public void SelectIngameSlot()
    {
        if (_runtime == null) return;
        var index = _runtime.SelectIndex(0);
        _view?.ChangeIngameSlot(index);
    }

    public void SelectInteractSlot()
    {
        if (_runtime == null) return;
        var index = _runtime.SelectInteractIndex(0);
        _view?.ChangeInteractSlot(index);
    }

    public void PostIndex()
    {
        if (_runtime == null) return;
        var index = _runtime.PostIndex();
        _view?.ChangeIngameSlot(index);
    }

    public void PreIndex()
    {
        if (_runtime == null) return;
        var index = _runtime.PreIndex();
        _view?.ChangeIngameSlot(index);
    }

    public void PostInteractIndex()
    {
        if (_runtime == null) return;
        var index = _runtime.PostInteractIndex();
        _view?.ChangeInteractSlot(index);
    }

    public void PreInteractIndex()
    {
        if (_runtime == null) return;
        var index = _runtime.PreInteractIndex();
        _view?.ChangeInteractSlot(index);
    }

    public void ValidateGetItem()
    {
        if (_runtime == null) return;
        var item = _runtime.ValidateGetItem();
    }

    public void OpenInteractHotbar()
    {
        if (_runtime == null) return;
        _runtime?.OpenInteractHotbar();
        _view?.OpenInteractHotbar(_runtime.Hotbar);
    }

    public void GetItem()
    {
        if (_runtime == null) return;
        var dropitem = _runtime.GetItem(ItemLabel.None, 0);
        _view?.GetItem(ItemLabel.None, 0);
    }

    public void UseItem()
    {
        if (_runtime == null) return;
        var result = _runtime.UseItem();
        _view?.UseItem(result.Item2);
    }
}