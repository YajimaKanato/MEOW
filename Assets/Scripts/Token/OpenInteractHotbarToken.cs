using MVPTools.Runtime;

/// <summary>アイテム交換をしなければいけないときのイベントトークン</summary>
public readonly struct OpenInteractHotbarToken : IToken
{
    public readonly ItemBase[] Hotbar;
    public readonly ItemBase GetItem;

    public OpenInteractHotbarToken(ItemBase[] hotbar, ItemBase getItem)
    {
        Hotbar = hotbar;
        GetItem = getItem;
    }
}