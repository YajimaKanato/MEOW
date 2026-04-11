using MVPTools.Runtime;

/// <summary>アクションマップを切り替える時のイベントトークン</summary>
public readonly struct NextActionMapToken : IToken
{
    public readonly ActionMap ActionMap;

    public NextActionMapToken(ActionMap actionMap)
    {
        ActionMap = actionMap;
    }
}