using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Item/ItemList")]
public class ItemList : ScriptableObject
{
    [SerializeField] ItemBase[] _items;

    public ItemBase[] Items => _items;

#if UNITY_EDITOR
    public void SetItems(ItemBase[] items)
    {
        _items = items;
    }
#endif
}
