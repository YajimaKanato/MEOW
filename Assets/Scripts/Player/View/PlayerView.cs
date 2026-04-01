using MVPTools.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public partial class PlayerView : ViewBase
{
    //Playerの核ファイル
    [SerializeField] InputActionAsset _actionAsset;
    [SerializeField] PlayerModel _model;
    InputActionMap _playerMap;
    InputAction _move;
    InputAction _run;
    InputAction _jump;
    InputAction _down;
    InputAction _interact;
    InputAction _useItem;
    InputAction _selectItem;
    InputAction _nextItem;
    InputAction _backItem;
    InputAction _menu;
    PlayerPresenter _presenter;
    Rigidbody2D _rb2d;
    Animator _animator;
    bool _subscribed;
    bool _running;
    float _walkSpeed;
    float _runSpeed;

    [ContextMenu("Initialize")]
    public override void Initialize()
    {
        //定義
        _presenter = new PlayerPresenter(this, _model);
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _walkSpeed = _model.WalkSpeed;
        _runSpeed = _model.RunSpeed;
        _running = false;

        //初期化処理
        _presenter?.Subscribe();
        SetActions();
        SubscribePlayerMap();
        _playerMap.Enable();
    }

    private void OnEnable()
    {
        _presenter?.Subscribe();
        SubscribePlayerMap();
    }

    private void OnDisable()
    {
        _presenter?.Unsubscribe();
        UnsubscribePlayerMap();
    }

    private void OnDestroy()
    {
        _presenter?.Dispose();
        _presenter = null;
        UnsubscribePlayerMap();
    }

    void SetActions()
    {
        _playerMap = _actionAsset.FindActionMap("Player");
        _move = _playerMap.FindAction("Move");
        _run = _playerMap.FindAction("Run");
        _jump = _playerMap.FindAction("Jump");
        _down = _playerMap.FindAction("Down");
        _interact = _playerMap.FindAction("Interact");
        _useItem = _playerMap.FindAction("UseItem");
        _selectItem = _playerMap.FindAction("SelectItem");
        _nextItem = _playerMap.FindAction("NextItem");
        _backItem = _playerMap.FindAction("BackItem");
        _menu = _playerMap.FindAction("Menu");
    }

    void SubscribePlayerMap()
    {
        if (_subscribed) return;
        if (_playerMap == null) return;
        _subscribed = true;
        _run.started += Run;
        _run.canceled += Run;
        _jump.started += Jump;
        _down.started += Down;
        _interact.started += Interact;
        _useItem.started += UseItem;
        _selectItem.started += SelectItem;
        _nextItem.started += NextItem;
        _backItem.started += BackItem;
        _menu.started += Menu;
    }

    public void UnsubscribePlayerMap()
    {
        if (!_subscribed) return;
        if (_playerMap == null) return;
        _subscribed = false;
        _run.started -= Run;
        _run.canceled -= Run;
        _jump.started -= Jump;
        _down.started -= Down;
        _interact.started -= Interact;
        _useItem.started -= UseItem;
        _selectItem.started -= SelectItem;
        _nextItem.started -= NextItem;
        _backItem.started -= BackItem;
        _menu.started -= Menu;
    }

    private void Update()
    {
        if (!_rb2d) return;
    }

    private void FixedUpdate()
    {
        if (!_rb2d) return;
        Move();
    }
}
