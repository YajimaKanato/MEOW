using MVPTools.Runtime;
using UnityEngine;

public class PlayerPresenter : ISubscribable
{
    PlayerView _view;
    PlayerRuntime _runtime;
    NearestInteractorCalculator _calculator;
    bool _subscribed;

    public PlayerPresenter(PlayerView view, PlayerModel model)
    {
        _view = view;
        _calculator = new(_view.gameObject);
        if (!RuntimeStorage.TryGetData(view.ID, out var data) || !(data is PlayerRuntime typed))
        {
            _runtime = new PlayerRuntime(model);
            RuntimeStorage.RegisterData(view.ID, _runtime);
        }
        else
        {
            _runtime = typed;
        }
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
        EventBus.Subscribe<GiveItemToken>(this, GetItem);
    }

    public void Unsubscribe()
    {
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }

    #region Ingame
    public void Move(Vector2 dir)
    {
        dir *= _runtime.GetMoveSpeed();
        _view.Move(dir);
    }

    public void Run(bool isRunning)
    {
        _runtime.Run(isRunning);
    }

    public void Jump()
    {
        if (!_runtime.IsGround) return;
        _view?.Jump(Vector2.up * _runtime.JumpPower);
    }

    public void Ground(bool isGround)
    {
        _runtime.Ground(isGround);
    }

    public void Down(bool isFalling)
    {
        _runtime.Down(isFalling);
    }

    public void SelectHotbar(int index)
    {
        _runtime.SelectIndex(index);
        EventBus.Publish(new SelectIngameHotbarToken(index));
    }

    public void MoveHotbar(SlotMove index)
    {
        _runtime.MoveIndex(index);
        EventBus.Publish(new MoveIngameHotbarToken(index));
    }

    void GetItem(GiveItemToken token)
    {
        _runtime.GetItem(token.Item);
        EventBus.Publish(new GetItemToken(_view.ID));
    }

    public void Interact()
    {
        _calculator?.NearestInteractor.Interact();
        EventBus.Publish(new NextActionMapToken(ActionMap.Interact));
    }
    #endregion

    #region Interact
    public void PushEnter()
    {
        EventBus.Publish(new PushEnterOnInteractToken());
    }

    public void Cancel()
    {

    }

    public void SelectInteractHotbar(int index)
    {
        EventBus.Publish(new SelectInteractHotbarToken(index));
    }

    public void MoveInteractHotbar(SlotMove index)
    {
        EventBus.Publish(new MoveInteractHotbarToken(index));
    }
    #endregion

    public void RegisterInteractor(InteractableView interactor)
    {
        _calculator?.RegisterInteractor(interactor);
    }

    public void RemoveInteractor(InteractableView interactor)
    {
        _calculator?.RemoveInteractor(interactor);
    }

    public void CalculateNearestInteractor()
    {
        _calculator?.CalculateNearestInteractor();
    }
}