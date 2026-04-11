using MVPTools.Runtime;
using UnityEngine;

public partial class ActionMapView : ViewBase
{
    [SerializeField] ActionMapModel _model;
    ActionMapPresenter _presenter;

    public override void Initialize()
    {
        foreach (var actionMap in _actionAsset.actionMaps)
        {
            actionMap?.Disable();
        }
        _presenter = new ActionMapPresenter(this, _model);
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
