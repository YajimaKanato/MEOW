using MVPTools.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public partial class PlayerView : ViewBase
{
    //Playerの核ファイル
    [SerializeField] InputActionAsset _actionAsset;
    [SerializeField] PlayerModel _model;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] Vector3 _groundLineOffsetY = new Vector2(0, -0.5f);
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
    Coroutine _calculateNearestInteractorCoroutine;
    Vector2 _groundLineStart;
    Vector2 _groundLineEnd;
    bool _subscribed;

    private void Awake()
    {
        Initialize();
    }

    [ContextMenu("Initialize")]
    public override void Initialize()
    {
        //定義
        _presenter = new PlayerPresenter(this, _model);
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

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
        _jump.started += Jump;
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
        _jump.started -= Jump;
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
        var line = transform.position + _groundLineOffsetY;
        _groundLineStart = line + Vector3.left / 2;
        _groundLineEnd = line + Vector3.right / 2;
#if UNITY_EDITOR
        Debug.DrawLine(_groundLineStart, _groundLineEnd, Color.red);
#endif
        _presenter?.Ground(Physics2D.Linecast(_groundLineStart, _groundLineEnd, _groundLayer));
        Run();
        Down();
    }

    private void FixedUpdate()
    {
        if (!_rb2d) return;
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<InteractableView>(out var interactor)) return;
        RegisterInteractor(interactor);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<InteractableView>(out var interactor)) return;
        RemoveInteractor(interactor);
    }
}
