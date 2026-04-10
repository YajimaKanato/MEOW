using MVPTools.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public partial class PlayerView
{
    //PlayerのActionMethodファイル
    #region Ingame
    void Move()
    {
        _presenter?.Move(_move.ReadValue<Vector2>());
    }

    void Run()
    {
        _presenter?.Run(_run.IsPressed());
    }

    void Jump(InputAction.CallbackContext ctx)
    {
        _presenter?.Jump();
    }

    void Down()
    {
        _presenter?.Down(_down.IsPressed());
    }

    void Interact(InputAction.CallbackContext ctx)
    {
        _presenter?.Interact();
    }

    void UseItem(InputAction.CallbackContext ctx)
    {

    }

    void SelectItem(InputAction.CallbackContext ctx)
    {
        var key = (KeyControl)ctx.control;
        var index = -1;
        if (Key.Digit1 <= key.keyCode && key.keyCode <= Key.Digit6)
        {
            index = key.keyCode - Key.Digit1;
        }

        if (Key.Numpad1 <= key.keyCode && key.keyCode <= Key.Numpad6)
        {
            index = key.keyCode - Key.Numpad1;
        }

        if (index != -1) _presenter?.SelectHotbar(index);
    }

    void NextItem(InputAction.CallbackContext ctx)
    {
        _presenter?.MoveHotbar(SlotMove.Post);
    }

    void BackItem(InputAction.CallbackContext ctx)
    {
        _presenter?.MoveHotbar(SlotMove.Pre);
    }

    void Menu(InputAction.CallbackContext ctx)
    {

    }

    void RegisterInteractor(InteractableView interactor)
    {
        _presenter?.RegisterInteractor(interactor);
    }

    void RemoveInteractor(InteractableView interactor)
    {
        _presenter?.RemoveInteractor(interactor);
    }
    #endregion

    #region Interact
    void Enter(InputAction.CallbackContext ctx)
    {
        _presenter?.PushEnter();
    }

    void Cancel(InputAction.CallbackContext ctx)
    {

    }

    void SelectItemOnInteract(InputAction.CallbackContext ctx)
    {

    }

    void NextItemOnInteract(InputAction.CallbackContext ctx)
    {

    }

    void BackItemOnInteract(InputAction.CallbackContext ctx)
    {

    }

    void MenuOnInteract(InputAction.CallbackContext ctx)
    {

    }
    #endregion
}