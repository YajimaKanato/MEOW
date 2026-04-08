using MVPTools.Runtime;
using UnityEngine;

public partial class InteractableView : ViewBase
{
    [SerializeField] InteractableModel _model;
    InteractablePresenter _presenter;

    public override void Initialize()
    {
        _presenter = new InteractablePresenter(this, _model);
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
