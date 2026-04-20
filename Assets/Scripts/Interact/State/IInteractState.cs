using UnityEngine;

public interface IInteractState
{
    void Entry();
    void PushEnter();
    void SelectIndex(int index);
    void MoveIndex(SlotMove move);
    void Exit();
}
