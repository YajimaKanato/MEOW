using MVPTools.Runtime;

/// <summary>フラグを下げる時のイベントトークン</summary>
public readonly struct RemoveFlagToken : IToken
{
    public readonly ConditionKey Key;

    public RemoveFlagToken(ConditionKey key)
    {
        Key = key;
    }
}