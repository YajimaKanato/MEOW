using MVPTools.Runtime;
using UnityEngine;

public class SelectState : SelectStateBase
{
    public SelectState(InteractView view, InteractPresenter presenter, InteractRuntime runtime) : base(view, presenter, runtime)
    {
    }

    public override void Entry()
    {
        base.Entry();
        if (!RuntimeStorage.TryGetData<PlayerRuntime>(CharacterType.Player.ToString(), out var player)) return;
        for (int i = 0; i < _choiceLength + 1; i++)
        {
            if (_choices[i] == null) return;
            if (i == _choiceLength)
            {
                _view.SetSelect(_runtime.Item, _choices[i].ConditionText, i);
            }
            else
            {
                _view.SetSelect(player.Hotbar[i], _choices[i].ConditionText, i);
            }
        }
    }

    public override void PushEnter()
    {
        EventBus.Publish(new SetFlagToken(ConditionKey.HaveAnyFood));
        EventBus.Publish(new GiveItemToken(_runtime.Item, _index));
        base.PushEnter();
    }
}
