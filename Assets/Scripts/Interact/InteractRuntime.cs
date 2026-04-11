using MVPTools.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRuntime : IRuntime
{
    CharacterType _currentTalker;
    TextSpeed _currentTextSpeed;
    Dictionary<CharacterType, string> _storyDict = new();

    public TextSpeed CurrentTextSpeed => _currentTextSpeed;

    public InteractRuntime(InteractModel definition)
    {
        _currentTextSpeed = definition.TextSpeed;
    }

    public void Dispose()
    {

    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public void ChangeTextSpeed(TextSpeed textSpeed)
    {
        _currentTextSpeed = textSpeed;
    }

    public void SetTalker(CharacterType characterType)
    {
        if (characterType == CharacterType.None) return;
        _currentTalker = characterType;
    }

    public string GetText()
    {
        if (!_storyDict.TryGetValue(_currentTalker, out var story)) return "これはテストです";
        return story;
    }
}
