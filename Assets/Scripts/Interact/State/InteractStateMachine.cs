using UnityEngine;

public class InteractStateMachine
{
    IEnterState _currentState;

    public void ChangeState(IEnterState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Entry();
    }

    public void Execute()
    {
        _currentState?.PushEnter();
    }
}
