using MVPTools.Runtime;
using UnityEngine;

public class PlayerPresenter : ISubscribable
{
    PlayerView _view;
    PlayerRuntime _runtime;
    bool _subscribed;

    public PlayerPresenter(PlayerView view, PlayerModel model)
    {
        _view = view;
        _runtime = model.CreateRuntime();
    }

    public void Dispose()
    {
        _runtime?.Dispose();
        _runtime = null;
        Unsubscribe();
    }

    public void Subscribe()
    {
        if (_subscribed) return;
        _subscribed = true;
        //EventBus.Subscribe<>(this,);
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }

    public void Move(Vector2 dir)
    {
        if (_runtime == null) return;
        dir *= _runtime.GetMoveSpeed();
        _view.Move(dir);
    }

    public void Run(bool isRunning)
    {
        if (_runtime == null) return;
        _runtime.Run(isRunning);
    }

    public void Jump()
    {
        if (_runtime == null) return;
        if (!_runtime.IsGround) return;
        _view?.Jump(Vector2.up * _runtime.JumpPower);
    }

    public void Ground(bool isGround)
    {
        if (_runtime == null) return;
        _runtime.Ground(isGround);
    }

    public void Down(bool isFalling)
    {
        if (_runtime == null) return;
        _runtime.Down(isFalling);
    }

    public void SelectHotbar(int index)
    {
        EventBus.Publish(new SelectIngameHotbarToken(index));
    }

    public void MoveHotbar(SlotMove index)
    {
        EventBus.Publish(new MoveIngameHotbarToken(index));
    }
}