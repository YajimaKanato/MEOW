using MVPTools.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public partial class PlayerView
{
    //PlayerのActionMethodファイル
    void Move()
    {
        var dir = _move.ReadValue<Vector2>() * (_running ? _runSpeed : _walkSpeed);
        dir.y = _rb2d.linearVelocityY;
        _rb2d.linearVelocity = dir;
    }

    void Run()
    {
        if (_isGround) _running = _run.IsPressed();
    }

    void Jump(InputAction.CallbackContext ctx)
    {
        if (_isGround) _rb2d.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }

    void Down()
    {
        if (_isGround) _isFalling = _down.IsPressed();
    }

    void Interact(InputAction.CallbackContext ctx)
    {

    }

    void UseItem(InputAction.CallbackContext ctx)
    {

    }

    void SelectItem(InputAction.CallbackContext ctx)
    {
        var key = (KeyControl)ctx.control;
        if(Key.Digit1<=key.keyCode&&key.keyCode<=Key.Digit6)
        {
            var index = key.keyCode - Key.Digit1;
        }

        if (Key.Numpad1 <= key.keyCode && key.keyCode <= Key.Numpad6)
        {
            var index = key.keyCode - Key.Numpad1;
        }
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