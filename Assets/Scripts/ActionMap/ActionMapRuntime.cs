using MVPTools.Runtime;
using System.Collections.Generic;

public class ActionMapRuntime : IRuntime
{
    ActionMap _currentActionMap;
    Stack<ActionMap> _actionMapStack = new();

    public ActionMapRuntime(ActionMapModel model)
    {
        _currentActionMap = model.ActionMap;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public ActionMap NextActionMap(ActionMap actionMap)
    {
        if (actionMap != ActionMap.None)
        {
            _actionMapStack.Push(_currentActionMap);
            _currentActionMap = actionMap;
        }
        return _currentActionMap;
    }

    public ActionMap GetPreActionMap()
    {
        if (_actionMapStack.Count > 0)
        {
            _currentActionMap = _actionMapStack.Pop();
        }
        return _currentActionMap;
    }
}