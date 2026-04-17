using UnityEngine;

public class FinishEnter : IEnterState
{
    InteractPresenter _interactPresenter;

    public FinishEnter(InteractPresenter presenter)
    {
        _interactPresenter = presenter;
    }

    public void Entry()
    {
#if UNITY_EDITOR
        Debug.Log($"Entry {nameof(FinishEnter)}");
#endif
    }

    public void Exit()
    {
#if UNITY_EDITOR
        Debug.Log($"Exit {nameof(FinishEnter)}");
#endif
    }

    public void PushEnter()
    {
        _interactPresenter?.FinishInteract();
    }
}
