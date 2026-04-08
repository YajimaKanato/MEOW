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
        _view?.OpenIngameHotbar(_runtime.Hotbar);
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
        EventBus.Subscribe<SelectInteractHotbarToken>(this, SelectInteractSlot);
        EventBus.Subscribe<MoveIngameHotbarToken>(this, MoveIngameIndex);
        EventBus.Subscribe<MoveInteractHotbarToken>(this, MoveInteractIndex);
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }

    public void SelectIngameSlot(SelectIngameHotbarToken token)
    {
        if (_runtime == null) return;
        var index = _runtime.SelectIndex(token.Index);
        _view?.ChangeIngameSlot(index);
    }

    public void SelectInteractSlot(SelectInteractHotbarToken token)
    {
        if (_runtime == null) return;
        var index = _runtime.SelectInteractIndex(token.Index);
        _view?.ChangeInteractSlot(index);
    }

    public void MoveIngameIndex(MoveIngameHotbarToken token)
    {
        if (_runtime == null) return;
        var index = _runtime.MoveIndex(token.Move);
        _view?.ChangeIngameSlot(index);
    }

    public void MoveInteractIndex(MoveInteractHotbarToken token)
    {
        if (_runtime == null) return;
        var index = _runtime.MoveInteractIndex(token.Move);
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

    public void CloseInteractHotbar()
    {

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