using MVPTools.Runtime;

/// <summary>アイテムを使ったときのイベントトークン</summary>
public readonly struct UseItemToken : IToken
{
    public readonly ItemBase[] Hotbar;

    public UseItemToken(ItemBase[] hotbar)
    {
        Hotbar = hotbar;
    }
}