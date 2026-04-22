using MVPTools.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InteractView
{
    [SerializeField] InteractWindow _interactWindow;
    [SerializeField] GetItemWindow _getItemWindow;
    [SerializeField] ChoiceUI[] _choices;
    Dictionary<CharacterType, Sprite> _spriteDict = new();
    Dictionary<CharacterType, string> _nameDict = new();
    Dictionary<NodeType, Selectable> _selectableDict = new();
    Selectable _currentSelectable;
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

    public void OpenChoice(NodeType nodeType)
    {
        if (!_selectableDict.TryGetValue(nodeType, out _currentSelectable)) return;
        _currentSelectable?.gameObject?.SetActive(true);
        _currentSelectable?.OpenSelectable();
    }

    public void SetSelect(ItemLabel item, string text, int index)
    {
        if (_currentSelectable == null) return;
        if (!_itemList.TryGetItem(item, out var sprite)) return;
        if (_currentSelectable.gameObject.activeSelf) _currentSelectable.SetElements(sprite.ItemSprite, text, index);
    }

    public void ChangeSlot(int index)
    {
        if (_currentSelectable == null) return;
        if (_currentSelectable.gameObject.activeSelf) _currentSelectable.SelectIndex(index);
    }

    public void CloseChoice()
    {
        _currentSelectable?.gameObject?.SetActive(false);
    }

    [Serializable]
    class ChoiceUI
    {
        [SerializeField] NodeType _nodeType;
        [SerializeField] Selectable _ui;

        public NodeType NodeType => _nodeType;
        public Selectable UI => _ui;
    }
}