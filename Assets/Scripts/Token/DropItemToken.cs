using MVPTools.Runtime;

/// <summary>アイテム交換をした時のイベントトークン</summary>
public readonly struct DropItemToken : IToken
{
    public readonly string ID;
    public readonly ItemLabel Item;

    public DropItemToken(string id, ItemLabel item)
    {
        ID = id;
        Item = item;
    }
}