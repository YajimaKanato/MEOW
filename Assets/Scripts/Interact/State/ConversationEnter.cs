using UnityEngine;

public class ConversationEnter : IEnterState
{
    InteractPresenter _presenter;

    public ConversationEnter(InteractPresenter presenter)
    {
        _presenter = presenter;
    }

    public void Entry()
    {
        _presenter?.StreamText();
    }

    public void Exit()
    {

    }

    public void PushEnter()
    {
        _presenter?.ChangeState();
    }
}
