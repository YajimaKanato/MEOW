using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Item/ItemList")]
public class ItemList : ScriptableObject
{
    [SerializeField] ItemBase[] _items;
    Dictionary<ItemLabel, ItemBase> _itemDict;

    public ItemBase[] Items => _items;

#if UNITY_EDITOR
    public void SetItems(ItemBase[] items)
    {
        _items = items;
    }
#endif

    public bool TryGetItem(ItemLabel itemLabel, out ItemBase result)
    {
        if (_itemDict == null)
        {
            _itemDict = new();
            foreach (var item in _items)
            {
                _itemDict.Add(item.ItemLabel, item);
            }
        }
        return _itemDict.TryGetValue(itemLabel, out result);
    }
}
