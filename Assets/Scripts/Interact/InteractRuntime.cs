using MVPTools.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRuntime : IRuntime
{
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

    public string GetText(CharacterType characterType)
    {
        if (!_storyDict.TryGetValue(characterType, out var story)) return "これはテストです";
        return story;
    }
}
