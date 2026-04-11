using MVPTools.Runtime;
using UnityEngine;

public partial class InteractView : ViewBase
{
    [SerializeField] InteractModel _model;
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
        CloseInteractWindow();
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
