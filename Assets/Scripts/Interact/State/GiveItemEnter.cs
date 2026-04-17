using UnityEngine;

public class GiveItemEnter : IEnterState
{
    InteractPresenter _interactPresenter;

    public GiveItemEnter(InteractPresenter presenter)
    {
        _interactPresenter = presenter;
    }

    public void Entry()
    {
        _interactPresenter?.GiveItem();
#if UNITY_EDITOR
        Debug.Log($"Entry {nameof(GiveItemEnter)}");
#endif
    }

    public void Exit()
    {
#if UNITY_EDITOR
        Debug.Log($"Exit {nameof(GiveItemEnter)}");
#endif
    }

    public void PushEnter()
    {
        _interactPresenter?.OpenHotbar();
    }
}
