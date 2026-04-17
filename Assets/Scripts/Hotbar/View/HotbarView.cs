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
        var hotbar = new ItemLabel[_model.Hotbar.Length];
        for (int i = 0; i < hotbar.Length; i++)
        {
            hotbar[i] = _model.Hotbar[i] != null ? _model.Hotbar[i].ItemLabel : ItemLabel.None;
        }

        UpdateIngameHotbar(hotbar, _model.DefaultIndex);
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
