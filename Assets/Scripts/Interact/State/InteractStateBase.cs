using UnityEngine;

public abstract class InteractStateBase : IInteractState
{
    protected InteractView _view;
    protected InteractPresenter _presenter;
    protected InteractRuntime _runtime;

    public InteractStateBase(InteractView view, InteractPresenter presenter, InteractRuntime runtime)
    {
        _view = view;
        _presenter = presenter;
        _runtime = runtime;
    }

    public abstract void Entry();
    public abstract void Exit();
    public abstract void MoveIndex(SlotMove move);
    public abstract void PushEnter();
    public abstract void SelectIndex(int index);
}
