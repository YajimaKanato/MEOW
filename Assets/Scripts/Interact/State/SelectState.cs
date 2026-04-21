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
        for (int i = 0; i < _choiceLength; i++)
        {
            if (_choices[i] == null) return;
            _view.SetSelect(player.Hotbar[i], _choices[i].ConditionText, i);
        }
    }
}
