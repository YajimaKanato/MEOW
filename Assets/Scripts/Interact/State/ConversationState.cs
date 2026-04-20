using UnityEngine;

public class ConversationState : InteractStateBase
{
    public ConversationState(InteractView view, InteractPresenter presenter, InteractRuntime runtime) : base(view, presenter, runtime)
    {
    }

    public override void Entry()
    {
        var paragraph = _presenter.CurrentParagraph;
        _view?.OpenInteractWindow();
        _view?.StartStreamText(_presenter.StreamText(paragraph.Text));
        _view?.SetTalkers(paragraph.LeftTalker, paragraph.RightTalker);
        switch (paragraph.TalkerType)
        {
            case CurrentTalker.Left:
                _view?.TalkLeft(paragraph.LeftTalker);
                break;
            case CurrentTalker.Right:
                _view?.TalkRight(paragraph.RightTalker);
                break;
            case CurrentTalker.Narration:
                _view?.TalkNarration();
                break;
        }
    }

    public override void Exit()
    {

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
