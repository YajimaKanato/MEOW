using UnityEngine;

public class InteractStateMachine
{
    IInteractState _currentState;

    public void ChangeState(IInteractState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Entry();
    }

    public void PushEnter()
    {
        _currentState?.PushEnter();
    }

    public void SelectIndex(int index)
    {
        _currentState?.SelectIndex(index);
    }

    public void MoveIndex(SlotMove move)
    {
        _currentState?.MoveIndex(move);
    }
}
