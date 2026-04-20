using System.Collections.Generic;
using UnityEngine;

public class NearestInteractorCalculator
{
    List<InteractableView> _interactorList = new();
    InteractableView _nearestInteractor;
    GameObject _view;

    public InteractableView NearestInteractor => _nearestInteractor;

    public NearestInteractorCalculator(GameObject view)
    {
        _view = view;
    }

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
