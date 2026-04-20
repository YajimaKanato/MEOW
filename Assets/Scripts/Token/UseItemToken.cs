using MVPTools.Runtime;

/// <summary>アイテムを使ったときのイベントトークン</summary>
public readonly struct UseItemToken : IToken
{
    public readonly string ID;

    public UseItemToken(string id)
    {
        ID = id;
    }
}