using MVPTools.Runtime;
using System.Collections.Generic;

public class ActionMapRuntime : IRuntime
{
    ActionMap _currentActionMap;
    Stack<ActionMap> _actionMapStack = new();

    public ActionMapRuntime(ActionMapModel model)
    {
        _currentActionMap = model.ActionMap;
        _actionMapStack.Push(_currentActionMap);
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public void NextActionMap(ActionMap actionMap)
    {

        _currentActionMap = actionMap;
    }
}