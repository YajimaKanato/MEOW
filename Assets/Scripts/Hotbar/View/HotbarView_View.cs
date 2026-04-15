using MVPTools.Runtime;
using System.Collections.Generic;
using UnityEngine;

public partial class HotbarView
{
    //Viewの表示部分を実装
    [SerializeField] Hotbar _ingameHotbar;
    Dictionary<ItemLabel, Sprite> _spriteDict = new();

    public void UpdateIngameHotbar(ItemBase[] items, int index)
    {
        var list = new Sprite[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null) continue;
            if (!_spriteDict.TryGetValue(items[i].ItemLabel, out var sprite)) continue;
            list[i] = sprite;
        }
        _ingameHotbar?.OpenHotbar(list, index);
    }

    public void ChangeSlot(int index)
    {
        _ingameHotbar?.ChangeSlot(index);
    }
}