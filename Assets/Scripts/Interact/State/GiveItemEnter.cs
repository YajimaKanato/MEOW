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
    }

    public void Exit()
    {

    }

    public void PushEnter()
    {
        _interactPresenter?.OpenHotbar();
    }
}
