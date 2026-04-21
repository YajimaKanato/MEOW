using UnityEngine;
using MVPTools.Runtime;

public abstract class SelectStateBase : InteractStateBase
{
    protected Choice[] _choices;
    protected int _index;
    protected int _choiceLength;

    public SelectStateBase(InteractView view, InteractPresenter presenter, InteractRuntime runtime) : base(view, presenter, runtime)
    {
    }

    public override void Entry()
    {
        _choices = _presenter.CurrentConversation.Choices;
        _index = 0;
        _choiceLength = _choices.Length - 1;
        _view.OpenChoice(_presenter.CurrentParagraph.NodeType);
    }

    public override void Exit()
    {
        _view?.CloseChoice();
    }

    public override void MoveIndex(SlotMove move)
    {
        _index += (int)move;
        if (_index < 0) _index = _choiceLength;
        if (_index > _choiceLength) _index = 0;
        _view?.ChangeSlot(_index);
    }

    public override void PushEnter()
    {
        var conversation = _presenter.CurrentConversation.Choices;
        EventBus.Publish(new SetFlagToken(conversation[_index].ConditionKey));
        _presenter.NextConversation(conversation[_index].Next);
        _presenter.ChangeState();
    }

    public override void SelectIndex(int index)
    {
        if (index < 0 || _choiceLength < index) return;
        _index = index;
        _view?.ChangeSlot(_index);
    }
}
