using MVPTools.Runtime;

/// <summary>フラグを立てる時のイベントトークン</summary>
public readonly struct SetFlagToken : IToken
{
    public readonly ConditionKey Key;

    public SetFlagToken(ConditionKey key)
    {
        Key = key;
    }
}