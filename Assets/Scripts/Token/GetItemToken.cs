using MVPTools.Runtime;

/// <summary>アイテムを獲得した時のイベントトークン</summary>
public readonly struct GetItemToken : IToken
{
    public readonly string ID;

    public GetItemToken(string id)
    {
        ID = id;
    }
}