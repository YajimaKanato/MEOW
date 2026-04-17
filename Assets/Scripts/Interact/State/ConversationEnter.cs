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
#if UNITY_EDITOR
        Debug.Log($"Entry {nameof(ConversationEnter)}");
#endif
    }

    public void Exit()
    {
#if UNITY_EDITOR
        Debug.Log($"Exit {nameof(ConversationEnter)}");
#endif
    }

    public void PushEnter()
    {
        _presenter?.ChangeState();
    }
}
