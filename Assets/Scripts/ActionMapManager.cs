using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ActionMapManager
{
    readonly Stack<InputActionMap> _actionMapStack;

    public ActionMapManager(InputActionMap startActionMap)
    {
        _actionMapStack = new Stack<InputActionMap>();
        _actionMapStack.Push(startActionMap);
    }

    public void NextActionMap(InputActionMap actionMap)
    {
        if (actionMap == null) return;
        _actionMapStack.Peek()?.Disable();
        actionMap.Enable();
        _actionMapStack.Push(actionMap);
    }

    public void BackActionMap()
    {
        _actionMapStack.Pop()?.Disable();
        _actionMapStack.Peek()?.Enable();
    }

    public void Clear()
    {
        foreach (var actionMap in _actionMapStack)
        {
            actionMap.Disable();
        }
        _actionMapStack.Clear();
    }
}
