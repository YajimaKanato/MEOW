using MVPTools.Runtime;
using System.Collections.Generic;
using UnityEngine;

public partial class HotbarView
{
    //Viewの表示部分を実装
    [SerializeField] Hotbar _ingameHotbar;

    public void UpdateIngameHotbar(ItemLabel[] items, int index)
    {
        var list = new Sprite[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == ItemLabel.None) continue;
            if (!_itemList.TryGetItem(items[i], out var item)) continue;
            list[i] = item.ItemSprite;
        }
        _ingameHotbar?.OpenHotbar(list, index);
    }

    public void ChangeSlot(int index)
    {
        _ingameHotbar?.ChangeSlot(index);
    }
}