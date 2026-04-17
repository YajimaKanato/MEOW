using MVPTools.Runtime;

/// <summary>アイテムを獲得した時のイベントトークン</summary>
public readonly struct GetItemToken : IToken
{
    public readonly ItemLabel[] Hotbar;

    public GetItemToken(ItemLabel[] hotbar)
    {
        Hotbar = hotbar;
    }
}