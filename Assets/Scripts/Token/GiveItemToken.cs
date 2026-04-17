using MVPTools.Runtime;

/// <summary>アイテムを渡すときのイベントトークン</summary>
public readonly struct GiveItemToken : IToken
{
    public readonly ItemLabel[] Item;

    public GiveItemToken(ItemLabel[] item)
    {
        Item = item;
    }
}