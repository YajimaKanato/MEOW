using UnityEngine;

public class InteractStateMachine
{
    IInteractState _currentState;

    public void Init(IInteractState startState)
    {
        _currentState = startState;
        _currentState?.Entry();
    }

    public void ChangeState(IInteractState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Entry();
    }

    public void Execute()
    {
        _currentState?.Execute();
    }
}
