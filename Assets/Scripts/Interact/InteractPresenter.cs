using MVPTools.Runtime;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class InteractPresenter : ISubscribable
{
    InteractView _view;
    InteractRuntime _runtime;
    List<InteractableView> _interactorList = new();
    InteractableView _nearestInteractor;
    bool _subscribed;

    public InteractPresenter(InteractView view, InteractModel model)
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

    public void Interact()
    {

    }

    IEnumerator CalculateNearestInteractor()
    {
        var wait = new WaitForSeconds(0.1f);
        while (true)
        {
            if (_interactorList == null || _interactorList.Count <= 1)
            {
                yield return wait;
                continue;
            }

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

            if (nearestInteractor != null)
            {
                //一番近いキャラクターに選択可能表示などを出す
                _nearestInteractor = nearestInteractor;
            }
            yield return wait;
        }
    }
}