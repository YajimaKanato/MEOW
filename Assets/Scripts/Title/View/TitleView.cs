using MVPTools.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class TitleView : ViewBase
{
    [SerializeField] InputActionAsset _actionAseet;
    [SerializeField] TitleModel _model;
    InputActionMap _titleMap;
    InputAction _enter;
    InputAction _upElement;
    InputAction _downElement;
    TitlePresenter _presenter;
    bool _subscribed;

    public override void Initialize()
    {
        _presenter = new TitlePresenter(this, _model);
        _presenter?.Subscribe();
        SetActions();
        SubscribeMap();
    }

    private void OnEnable()
    {
        _presenter?.Subscribe();
        SubscribeMap();
    }

    private void OnDisable()
    {
        _presenter?.Unsubscribe();
        UnsubscribeMap();
    }

    private void OnDestroy()
    {
        _presenter?.Dispose();
        _presenter = null;
        UnsubscribeMap();
    }

    void SetActions()
    {
        _titleMap = _actionAseet.FindActionMap("Title");
        _enter = _titleMap.FindAction("Enter");
        _upElement = _titleMap.FindAction("UpElement");
        _downElement = _titleMap.FindAction("TitleElement");
    }

    void SubscribeMap()
    {
        if (_subscribed) return;
        if (_titleMap == null) return;
        _subscribed = true;
        _enter.started += Enter;
        _upElement.started += UpElement;
        _downElement.started += DownElemet;
    }

    void UnsubscribeMap()
    {
        if (!_subscribed) return;
        if (_titleMap == null) return;
        _subscribed = false;
        _enter.started -= Enter;
        _upElement.started -= UpElement;
        _downElement.started -= DownElemet;
    }
}
