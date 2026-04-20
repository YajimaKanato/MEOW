using MVPTools.Runtime;
using UnityEngine;

public class GiveItemState : InteractStateBase
{
    public GiveItemState(InteractView view, InteractPresenter presenter, InteractRuntime runtime) : base(view, presenter, runtime)
    {
    }

    public override void Entry()
    {
        if (!RuntimeStorage.TryGetData<InteractableRuntime>(_presenter.CurrentInteractor, out var data)) return;
        var item = data.Item;
        _view?.GetItem(item);
        if (RuntimeStorage.TryGetData<PlayerRuntime>(CharacterType.Player.ToString(), out var player))
        {
            if (player.ValidateGetItem(out var index))
            {
                _runtime.SetKey(ConditionKey.HaveAnyFood);
                EventBus.Publish(new GiveItemToken(item, index));
            }
            else
            {
                _runtime.SetKey(ConditionKey.HotbarIsFullness);
            }
        }
    }

    public override void Exit()
    {
        _view?.CloseGetItemWindow();
    }

    public override void MoveIndex(SlotMove move)
    {

    }

    public override void PushEnter()
    {
        _presenter.ChangeState();
    }

    public override void SelectIndex(int index)
    {

    }
}
