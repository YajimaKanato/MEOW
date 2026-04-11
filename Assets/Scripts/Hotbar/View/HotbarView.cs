using MVPTools.Runtime;
using UnityEngine;

public partial class HotbarView : ViewBase
{
    [SerializeField] ItemList _itemList;
    [SerializeField] HotbarModel _model;
    HotbarPresenter _presenter;

    public override void Initialize()
    {
        _presenter = new HotbarPresenter(this, _model);
        foreach (var item in _itemList.Items)
        {
            _spriteDict[item.ItemLabel] = item.ItemSprite;
        }

        CloseInteractHotbar();
        _presenter?.Subscribe();
    }

    private void OnEnable()
    {
        _presenter?.Subscribe();
    }

    private void OnDisable()
    {
        _presenter?.Unsubscribe();
    }

    private void OnDestroy()
    {
        _presenter?.Dispose();
        _presenter = null;
    }
}
