using MVPTools.Runtime;
using UnityEngine;
using UnityEngine.UI;

public partial class InteractView : ViewBase
{
    [SerializeField] ItemList _itemList;
    [SerializeField] InteractModel _model;
    [SerializeField] Image _back;
    InteractPresenter _presenter;

    public override void Initialize()
    {
        _presenter = new InteractPresenter(this, _model);
        _presenter?.Subscribe();
        foreach (var character in _model.Interactables.InteractableList)
        {
            if (character == null) continue;
            _spriteDict[character.CharacterType] = character.TalkingSprite;
            _nameDict[character.CharacterType] = character.CharacterName;
        }
        foreach(var selectable in _choices)
        {
            _selectableDict[selectable.NodeType] = selectable.UI;
        }
        CloseGetItemWindow();
        CloseHotbar();
        CloseInteractWindow();
        if (_back != null) _back.enabled = false;
    }

    private void OnEnable()
    {
        _presenter?.Subscribe();
    }

    private void OnDisable()
    {
        _presenter?.Unsubscribe();
    }

    private void OnDestroy()
    {
        _presenter?.Dispose();
        _presenter = null;
    }
}
