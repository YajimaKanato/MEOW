using MVPTools.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InteractView
{
    [SerializeField] InteractWindow _interactWindow;
    [SerializeField] Hotbar _hotbar;
    [SerializeField] GetItemWindow _getItemWindow;
    Dictionary<CharacterType, Sprite> _spriteDict = new();
    Dictionary<CharacterType, string> _nameDict = new();
    //Viewの表示部分を実装
    public void ActivateBack()
    {
        if (_back != null) _back.enabled = true;
    }

    void InactivateBack()
    {
        if (_back != null) _back.enabled = false;
    }

    public void OpenInteractWindow()
    {
        if (_interactWindow.gameObject.activeSelf) return;
        _interactWindow?.gameObject?.SetActive(true);
        _interactWindow?.ResetWindow();
        _interactWindow?.SetTalkers(null, null);
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
        InactivateBack();
        _interactWindow?.gameObject?.SetActive(false);
    }

    public void GetItem(ItemLabel getItem)
    {
        if (!_itemList.TryGetItem(getItem, out var item)) return;
        _getItemWindow?.gameObject?.SetActive(true);
        _getItemWindow?.GetItem(item.ItemSprite, item.ItemName, item.ItemInfo, false);
    }

    public void CloseGetItemWindow()
    {
        _getItemWindow?.gameObject.SetActive(false);
    }

    public void OpenHotbar(ItemLabel[] hotbar, ItemLabel getItem)
    {
        CloseGetItemWindow();
        var list = new Sprite[hotbar.Length];
        for (int i = 0; i < hotbar.Length; i++)
        {
            if (hotbar[i] == ItemLabel.None) continue;
            if (!_itemList.TryGetItem(hotbar[i], out var item)) continue;
            list[i] = item.ItemSprite;
        }
        _hotbar?.gameObject?.SetActive(true);
        _hotbar?.OpenHotbar(list, 0);
    }

    public void ChangeSlot(int index)
    {
        _hotbar?.ChangeSlot(index);
    }

    public void CloseHotbar()
    {
        _hotbar?.gameObject?.SetActive(false);
    }
}