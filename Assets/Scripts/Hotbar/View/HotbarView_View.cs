using MVPTools.Runtime;
using System.Collections.Generic;
using UnityEngine;

public partial class HotbarView
{
    //Viewの表示部分を実装
    [Header("各ホットバー")]
    [SerializeField] Hotbar _ingameHotbar;
    [SerializeField] Hotbar _interactHotbar;
    Dictionary<ItemLabel, Sprite> _spriteDict = new();

    public void OpenIngameHotbar(ItemLabel[] items)
    {
        var list = new Sprite[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            if (!_spriteDict.TryGetValue(items[i], out var sprite)) continue;
            list[i] = sprite;
        }
        _ingameHotbar?.OpenHotbar(list);
    }

    public void OpenInteractHotbar(ItemLabel[] items)
    {
        var list = new Sprite[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            if (!_spriteDict.TryGetValue(items[i], out var sprite)) continue;
            list[i] = sprite;
        }
        _interactHotbar?.OpenHotbar(list);
    }

    public void CloseInteractHotbar()
    {
        _interactHotbar?.CloseHotbar();
    }

    public void ChangeIngameSlot(int index)
    {
        _ingameHotbar?.ChangeSlot(index);
    }

    public void ChangeInteractSlot(int index)
    {
        _interactHotbar?.ChangeSlot(index);
    }

    public void GetItem(ItemLabel item, int index)
    {
        if (!_spriteDict.TryGetValue(item, out var sprite)) return;
        _ingameHotbar?.GetItem(sprite, index);
    }

    public void UseItem(int index)
    {
        _ingameHotbar?.UseItem(index);
    }
}