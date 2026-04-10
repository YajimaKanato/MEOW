using MVPTools.Runtime;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public partial class InteractableView : ViewBase
{
    [SerializeField] InteractableModel _model;
    InteractablePresenter _presenter;

    private void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        _presenter = new InteractablePresenter(this, _model);
        _presenter?.Subscribe();
        GetComponent<BoxCollider2D>().isTrigger = true;
        tag = "Interactor";
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
