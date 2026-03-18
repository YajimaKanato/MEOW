using UnityEngine;
using UnityEngine.InputSystem;

public class MenuObject : MonoBehaviour
{
    [SerializeField] InputActionAsset _actionAsset;
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

    private void Awake()
    {
        SetActions();
    }

    private void OnEnable()
    {
        SubscribeUIMap();
    }

    private void OnDisable()
    {
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

    void SelectCategory(InputAction.CallbackContext ctx)
    {

    }

    void NextCategory(InputAction.CallbackContext ctx)
    {

    }

    void BackCategory(InputAction.CallbackContext ctx)
    {

    }

    void UpElement(InputAction.CallbackContext ctx)
    {

    }

    void DownElement(InputAction.CallbackContext ctx)
    {

    }

    void RightElement(InputAction.CallbackContext ctx)
    {

    }

    void LeftElement(InputAction.CallbackContext ctx)
    {

    }

    void Enter(InputAction.CallbackContext ctx)
    {

    }

    void Cancel(InputAction.CallbackContext ctx)
    {

    }
}
