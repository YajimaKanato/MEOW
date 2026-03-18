using UnityEngine;
using UnityEngine.InputSystem;

public class InteractObject : MonoBehaviour
{
    [SerializeField] InputActionAsset _actionAseet;
    InputActionMap _interactMap;
    InputAction _enter;
    InputAction _cancel;
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
        SubscribeInteractMap();
    }

    private void OnDisable()
    {
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
        _enter.started += Enter;
        _cancel.started += Cancel;
        _selectItem.started += SelectItem;
        _nextItem.started += NextItem;
        _backItem.started += BackItem;
        _menu.started += Menu;
    }

    void UnsubscribeInteractMap()
    {
        _enter.started -= Enter;
        _cancel.started -= Cancel;
        _selectItem.started -= SelectItem;
        _nextItem.started -= NextItem;
        _backItem.started -= BackItem;
        _menu.started -= Menu;
    }

    void Enter(InputAction.CallbackContext ctx)
    {

    }

    void Cancel(InputAction.CallbackContext ctx)
    {

    }

    void SelectItem(InputAction.CallbackContext ctx)
    {

    }

    void NextItem(InputAction.CallbackContext ctx)
    {

    }

    void BackItem(InputAction.CallbackContext ctx)
    {

    }

    void Menu(InputAction.CallbackContext ctx)
    {

    }
}
