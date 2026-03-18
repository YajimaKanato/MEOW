using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerObject : MonoBehaviour
{
    //Playerの核ファイル
    [SerializeField] InputActionAsset _actionAsset;
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

    private void Awake()
    {
        SetActions();
    }

    private void OnEnable()
    {
        SubscribePlayerMap();
    }

    private void OnDisable()
    {
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
        _move.started += Move;
        _run.started += Run;
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
        _move.started -= Move;
        _run.started -= Run;
        _jump.started -= Jump;
        _down.started -= Down;
        _interact.started -= Interact;
        _useItem.started -= UseItem;
        _selectItem.started -= SelectItem;
        _nextItem.started -= NextItem;
        _backItem.started -= BackItem;
        _menu.started -= Menu;
    }
}
