using MVPTools.Runtime;

/// <summary>アイテムを渡すときのイベントトークン</summary>
public readonly struct GiveItemToken : IToken
{
    public readonly ItemLabel Item;
    public readonly int Index;

    public GiveItemToken(ItemLabel item, int index)
    {
        Item = item;
        Index = index;
    }
}