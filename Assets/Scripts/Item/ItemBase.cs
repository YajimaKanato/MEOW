using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    [Header("アイテムの情報")]
    [SerializeField] ItemType _itemType;
    [SerializeField] ItemLabel _itemLabel;
    [SerializeField] string _itemName;
    [SerializeField, TextArea] string _itemInfo;

    public ItemType ItemType => _itemType;
    public ItemLabel ItemLabel => _itemLabel;
    public string ItemName => _itemName;
    public string ItemInfo => _itemInfo;
}
