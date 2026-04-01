using MVPTools.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerView
{
    //PlayerのActionMethodファイル
    void Move()
    {
        var dir = _move.ReadValue<Vector2>() * (_running ? _runSpeed : _walkSpeed);
        _rb2d.linearVelocity = dir;
    }

    void Run(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _running = true;
        }
        else if (ctx.canceled)
        {
            _running = false;
        }
    }

    void Jump(InputAction.CallbackContext ctx)
    {

    }

    void Down(InputAction.CallbackContext ctx)
    {

    }

    void Interact(InputAction.CallbackContext ctx)
    {

    }

    void UseItem(InputAction.CallbackContext ctx)
    {

    }

    void SelectItem(InputAction.CallbackContext ctx)
    {

    }

    void NextItem(InputAction.CallbackContext ctx)
    {

    }

    void BackItem(InputAction.CallbackContext ctx)
    {

    }

    void Menu(InputAction.CallbackContext ctx)
    {

    }
}