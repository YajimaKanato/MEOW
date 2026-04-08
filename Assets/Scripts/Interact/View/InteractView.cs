using MVPTools.Runtime;
using UnityEngine;

public partial class InteractView : ViewBase
{
    [SerializeField] InteractModel _model;
    InteractPresenter _presenter;

    public override void Initialize()
    {
        _presenter = new InteractPresenter(this, _model);
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
