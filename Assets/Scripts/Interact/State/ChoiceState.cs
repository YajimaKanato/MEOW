using MVPTools.Runtime;
using UnityEngine;

public class ChoiceState : SelectStateBase
{
    public ChoiceState(InteractView view, InteractPresenter presenter, InteractRuntime runtime) : base(view, presenter, runtime)
    {
    }

    public override void Entry()
    {
        base.Entry();
        for (int i = 0; i < _choiceLength; i++)
        {
            if (_choices[i] == null) return;
            _view.SetSelect(ItemLabel.None, _choices[i].ConditionText, i);
        }
    }
}
