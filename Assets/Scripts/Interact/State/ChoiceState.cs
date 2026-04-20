using MVPTools.Runtime;
using UnityEngine;

public class ChoiceState : InteractStateBase
{
    int _index;
    int _choices;

    public ChoiceState(InteractView view, InteractPresenter presenter, InteractRuntime runtime) : base(view, presenter, runtime)
    {
    }

    public override void Entry()
    {
        var conversation = _presenter.CurrentConversation.Choices;
        _index = 0;
        _choices = conversation.Length - 1;
        _view.OpenHotbar(_presenter.CurrentParagraph.NodeType);
        for (int i = 0; i < _choices; i++)
        {
            if (conversation[i] == null) return;
            _view.SetSelect(ItemLabel.None, conversation[i].ConditionText, i);
        }
    }

    public override void Exit()
    {

    }

    public override void MoveIndex(SlotMove move)
    {
        _index += (int)move;
        if (_index < 0) _index = _choices;
        if (_index > _choices) _index = 0;
    }

    public override void PushEnter()
    {

    }

    public override void SelectIndex(int index)
    {
        if (index < 0 || _choices < index) return;
        _index = index;
    }
}
