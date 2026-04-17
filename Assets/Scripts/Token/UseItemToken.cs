using MVPTools.Runtime;

/// <summary>アイテムを使ったときのイベントトークン</summary>
public readonly struct UseItemToken : IToken
{
    public readonly ItemLabel[] Hotbar;

    public UseItemToken(ItemLabel[] hotbar)
    {
        Hotbar = hotbar;
    }
}