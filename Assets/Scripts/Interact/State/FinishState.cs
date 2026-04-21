using UnityEngine;

public class FinishState : InteractStateBase
{
    public FinishState(InteractView view, InteractPresenter presenter, InteractRuntime runtime) : base(view, presenter, runtime)
    {
    }

    public override void Entry()
    {
        _presenter.FinishInteract();
    }

    public override void Exit()
    {

    }

    public override void MoveIndex(SlotMove move)
    {

    }

    public override void PushEnter()
    {

    }

    public override void SelectIndex(int index)
    {

    }
}
