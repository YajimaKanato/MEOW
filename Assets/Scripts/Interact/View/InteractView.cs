using MVPTools.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class InteractView : ViewBase
{
    [SerializeField] InputActionAsset _actionAseet;
    [SerializeField] InteractModel _model;
    InputActionMap _interactMap;
    InputAction _enter;
    InputAction _cancel;
    InputAction _selectItem;
    InputAction _nextItem;
    InputAction _backItem;
    InputAction _menu;
    InteractPresenter _presenter;
    bool _subscribed;

    public override void Initialize()
    {
        _presenter = new InteractPresenter(this, _model);
        _presenter?.Subscribe();
        SetActions();
        SubscribeInteractMap();
    }

    private void OnEnable()
    {
        _presenter?.Subscribe();
        SubscribeInteractMap();
    }

    private void OnDisable()
    {
        _presenter?.Unsubscribe();
        UnsubscribeInteractMap();
    }

    private void OnDestroy()
    {
        _presenter?.Dispose();
        _presenter = null;
        UnsubscribeInteractMap();
    }

    void SetActions()
    {
        _interactMap = _actionAseet.FindActionMap("Interact");
        _enter = _interactMap.FindAction("Enter");
        _cancel = _interactMap.FindAction("Cancel");
        _selectItem = _interactMap.FindAction("SelectItem");
        _nextItem = _interactMap.FindAction("NextItem");
        _backItem = _interactMap.FindAction("BackItem");
        _menu = _interactMap.FindAction("Menu");
    }

    void SubscribeInteractMap()
    {
        if (_subscribed) return;
        if (_interactMap == null) return;
        _subscribed = true;
        _enter.started += Enter;
        _cancel.started += Cancel;
        _selectItem.started += SelectItem;
        _nextItem.started += NextItem;
        _backItem.started += BackItem;
        _menu.started += Menu;
    }

    void UnsubscribeInteractMap()
    {
        if (!_subscribed) return;
        if (_interactMap == null) return;
        _subscribed = false;
        _enter.started -= Enter;
        _cancel.started -= Cancel;
        _selectItem.started -= SelectItem;
        _nextItem.started -= NextItem;
        _backItem.started -= BackItem;
        _menu.started -= Menu;
    }
}
