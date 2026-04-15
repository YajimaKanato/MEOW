using MVPTools.Runtime;

/// <summary>アイテムを獲得した時のイベントトークン</summary>
public readonly struct GetItemToken : IToken
{
    public readonly ItemBase[] Hotbar;

    public GetItemToken(ItemBase[] hotbar)
    {
        Hotbar = hotbar;
    }
}