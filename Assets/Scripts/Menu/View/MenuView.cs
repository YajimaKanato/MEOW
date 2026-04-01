using MVPTools.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class MenuView : ViewBase
{
    [SerializeField] InputActionAsset _actionAsset;
    [SerializeField] MenuModel _model;
    InputActionMap _menuMap;
    InputAction _selectCategory;
    InputAction _nextCategory;
    InputAction _backCategory;
    InputAction _upElement;
    InputAction _downElement;
    InputAction _rightElement;
    InputAction _leftElement;
    InputAction _enter;
    InputAction _cancel;
    MenuPresenter _presenter;
    bool _subscribed;

    public override void Initialize()
    {
        _presenter = new MenuPresenter(this, _model);
        _presenter?.Subscribe();
        SetActions();
        SubscribeUIMap();
    }

    private void OnEnable()
    {
        _presenter?.Subscribe();
        SubscribeUIMap();
    }

    private void OnDisable()
    {
        _presenter?.Unsubscribe();
        UnsubscribeUIMap();
    }

    private void OnDestroy()
    {
        _presenter?.Dispose();
        _presenter = null;
        UnsubscribeUIMap();
    }

    void SetActions()
    {
        _menuMap = _actionAsset.FindActionMap("Menu");
        _selectCategory = _menuMap.FindAction("SelectCategory");
        _nextCategory = _menuMap.FindAction("NextCategory");
        _backCategory = _menuMap.FindAction("BackCategory");
        _upElement = _menuMap.FindAction("UpElement");
        _downElement = _menuMap.FindAction("DownElement");
        _rightElement = _menuMap.FindAction("RightElement");
        _leftElement = _menuMap.FindAction("LeftElement");
        _enter = _menuMap.FindAction("Enter");
        _cancel = _menuMap.FindAction("Cancel");
    }

    void SubscribeUIMap()
    {
        if (_subscribed) return;
        if (_menuMap == null) return;
        _subscribed = true;
        _selectCategory.started += SelectCategory;
        _nextCategory.started += NextCategory;
        _backCategory.started += BackCategory;
        _upElement.started += UpElement;
        _downElement.started += DownElement;
        _rightElement.started += RightElement;
        _leftElement.started += LeftElement;
        _enter.started += Enter;
        _cancel.started += Cancel;
    }

    void UnsubscribeUIMap()
    {
        if (!_subscribed) return;
        if (_menuMap == null) return;
        _subscribed = false;
        _selectCategory.started -= SelectCategory;
        _nextCategory.started -= NextCategory;
        _backCategory.started -= BackCategory;
        _upElement.started -= UpElement;
        _downElement.started -= DownElement;
        _rightElement.started -= RightElement;
        _leftElement.started -= LeftElement;
        _enter.started -= Enter;
        _cancel.started -= Cancel;
    }
}
