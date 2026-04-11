using MVPTools.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class ActionMapView
{
    [SerializeField] InputActionAsset _actionAsset;
    InputActionMap _currentActionMap;
    //Viewの表示部分を実装
    public void ChangeActionMap(ActionMap actionMap)
    {
        _currentActionMap?.Disable();
        _currentActionMap = _actionAsset.FindActionMap(actionMap.ToString());
        _currentActionMap?.Enable();
    }
}