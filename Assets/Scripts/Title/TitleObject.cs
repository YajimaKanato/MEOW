using UnityEngine;
using UnityEngine.InputSystem;

public class TitleObject : MonoBehaviour
{
    [SerializeField] InputActionAsset _actionAseet;
    InputActionMap _titleMap;
    InputAction _enter;
    InputAction _upElement;
    InputAction _downElement;

    private void Awake()
    {
        SetActions();
    }

    private void OnEnable()
    {
        SubscribeMap();
    }

    private void OnDisable()
    {
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
        _enter.started += Enter;
        _upElement.started += UpElement;
        _downElement.started += DownElemet;
    }

    void UnsubscribeMap()
    {
        _enter.started -= Enter;
        _upElement.started -= UpElement;
        _downElement.started -= DownElemet;
    }

    void Enter(InputAction.CallbackContext ctx)
    {

    }

    void UpElement(InputAction.CallbackContext ctx)
    {

    }

    void DownElemet(InputAction.CallbackContext ctx)
    {

    }
}
