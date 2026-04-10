using MVPTools.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : ISubscribable
{
    PlayerView _view;
    PlayerRuntime _runtime;
    List<InteractableView> _interactorList = new();
    InteractableView _nearestInteractor;
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

    public void Interact()
    {
        if (_nearestInteractor == null) return;
        _nearestInteractor.Interact();
        //ActionMap切り替え
    }

    public void PushEnter()
    {
        EventBus.Publish(new PushEnterOnInteractToken());
    }

    public void RegisterInteractor(InteractableView interactor)
    {
        if (interactor == null) return;
        if (!_interactorList.Contains(interactor)) _interactorList.Add(interactor);
        interactor.Selected();
    }

    public void RemoveInteractor(InteractableView interactor)
    {
        if (interactor == null) return;
        if (_interactorList.Contains(interactor)) _interactorList.Remove(interactor);
        interactor.Unselected();
    }

    public void CalculateNearestInteractor()
    {
        if (_interactorList == null || _interactorList.Count <= 1) return;

        InteractableView nearestInteractor = null;
        var minDistance = float.MaxValue;
        for (int i = 0; i < _interactorList.Count; i++)
        {
            var target = _interactorList[i];
            if (target == null) continue;
            var distance = Vector3.SqrMagnitude(_view.transform.position - target.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestInteractor = target;
            }
        }

        if (_nearestInteractor != nearestInteractor)
        {
            //一番近いキャラクターに選択可能表示などを出す
#if UNITY_EDITOR
            Debug.Log("対象切り替え");
#endif
            _nearestInteractor?.Unselected();
            _nearestInteractor = nearestInteractor;
            _nearestInteractor?.Selected();
        }
    }
}