using MVPTools.Runtime;

/// <summary>アイテムを渡すときのイベントトークン</summary>
public readonly struct GiveItemToken : IToken
{
    public readonly ItemBase Item;

    public GiveItemToken(ItemBase item)
    {
        Item = item;
    }
}