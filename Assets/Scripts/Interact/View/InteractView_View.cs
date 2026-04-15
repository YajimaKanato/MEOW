using MVPTools.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InteractView
{
    [SerializeField] InteractWindow _interactWindow;
    [SerializeField] Hotbar _hotbar;
    Dictionary<CharacterType, Sprite> _spriteDict = new();
    Dictionary<ItemLabel, Sprite> _hotbarSpriteDict = new();
    Dictionary<CharacterType, string> _nameDict = new();
    //Viewの表示部分を実装
    public void OpenInteractWindow()
    {
        _interactWindow?.gameObject?.SetActive(true);
    }

    public void SetTalkers(CharacterType left, CharacterType right)
    {
        if (!_spriteDict.TryGetValue(left, out var leftSprite) || !_spriteDict.TryGetValue(right, out var rightSprite)) return;
        _interactWindow?.SetTalkers(leftSprite, rightSprite);
    }

    public void TalkLeft(CharacterType talkCharacter)
    {
        if (!_nameDict.TryGetValue(talkCharacter, out var name)) return;
        _interactWindow?.TalkLeft(name);
    }

    public void TalkRight(CharacterType talkCharacter)
    {
        if (!_nameDict.TryGetValue(talkCharacter, out var name)) return;
        _interactWindow?.TalkRight(name);
    }

    public void TalkNarration()
    {
        _interactWindow?.TalkNarration();
    }

    public void StartStreamText(IEnumerator streamText)
    {
        StartCoroutine(streamText);
    }

    public void StreamText(string text)
    {
        _interactWindow?.UpdateTalkText(text);
    }

    public void CloseInteractWindow()
    {
        _interactWindow?.gameObject?.SetActive(false);
    }

    public void OpenHotbar(ItemBase[] hotbar, int index)
    {
        var list = new Sprite[hotbar.Length];
        for (int i = 0; i < hotbar.Length; i++)
        {
            if (hotbar[i] == null) continue;
            if (!_hotbarSpriteDict.TryGetValue(hotbar[i].ItemLabel, out var sprite)) continue;
            list[i] = sprite;
        }
        foreach (var item in _itemList.Items)
        {
            _hotbarSpriteDict[item.ItemLabel] = item.ItemSprite;
        }
        _hotbar?.OpenHotbar(list, index);
    }

    public void ChangeSlot(int index)
    {
        _hotbar?.ChangeSlot(index);
    }

    public void CloseHotbar()
    {
        _hotbar?.CloseHotbar();
    }
}