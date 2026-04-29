using MVPTools.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionState : InteractStateBase
{
    public SceneTransitionState(InteractView view, InteractPresenter presenter, InteractRuntime runtime) : base(view, presenter, runtime)
    {
    }

    public override void Entry()
    {
        _view.SceneTransition(PushEnter);
    }

    public override void Exit()
    {

    }

    public override void MoveIndex(SlotMove move)
    {

    }

    public override void PushEnter()
    {
        if (!RuntimeStorage.TryGetData<InteractableRuntime>(_presenter.CurrentInteractor, out var data)) return;
        SceneManager.LoadScene(data.SceneName.ToString());
        _presenter.ChangeState();
    }

    public override void SelectIndex(int index)
    {

    }
}
