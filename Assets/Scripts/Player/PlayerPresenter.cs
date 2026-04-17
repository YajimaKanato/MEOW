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
        if (_runtime == null) throw new System.NullReferenceException(nameof(_runtime));
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
        EventBus.Publish(new GetItemToken(_runtime.Hotbar));
    }

    public void Interact()
    {
        _nearestInteractor.Interact();
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
        if (interactor == null) return;
        if (!_interactorList.Contains(interactor)) _interactorList.Add(interactor);
        _nearestInteractor = interactor;
        _nearestInteractor?.Selected();
    }

    public void RemoveInteractor(InteractableView interactor)
    {
        if (interactor == null) return;
        if (_interactorList.Contains(interactor)) _interactorList.Remove(interactor);
        _nearestInteractor?.Unselected();
        _nearestInteractor = null;
    }

    public void CalculateNearestInteractor()
    {
        if (_interactorList == null || _interactorList.Count <= 0) return;

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