using MVPTools.Runtime;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public partial class InteractableView : ViewBase
{
    [SerializeField] protected InteractableModel _model;
    [SerializeField] CharacterType _characterType;
    [SerializeField] uint _num;
    protected InteractablePresenter _presenter;

    public override string ID => _characterType.ToString() + _num;

    public override void Initialize()
    {
        _presenter = new InteractablePresenter(this, _model);
        _presenter?.Subscribe();
        GetComponent<BoxCollider2D>().isTrigger = true;
        tag = "Interactor";
        _dropItem?.gameObject?.SetActive(false);
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
