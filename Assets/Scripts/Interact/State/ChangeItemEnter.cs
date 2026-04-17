using UnityEngine;

public class ChangeItemEnter : IEnterState
{
    InteractPresenter _interactPresenter;

    public ChangeItemEnter(InteractPresenter presenter)
    {
        _interactPresenter = presenter;
    }

    public void Entry()
    {

    }

    public void Exit()
    {

    }

    public void PushEnter()
    {
        _interactPresenter?.CloseHotbar();
    }
}
