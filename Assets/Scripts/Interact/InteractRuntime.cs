using MVPTools.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRuntime : IRuntime
{
    CharacterType _currentInteractor;
    TextSpeed _currentTextSpeed;
    Dictionary<CharacterType, ConversationAsset> _storyDict = new();
    Queue<Talker> _storyQueue = new();

    public TextSpeed CurrentTextSpeed => _currentTextSpeed;
    public bool ContinueStory => _storyQueue.Count > 0;

    public InteractRuntime(InteractModel definition)
    {
        _currentTextSpeed = definition.TextSpeed;
        var conversations = definition.StartConversations;
        foreach (var conversation in conversations)
        {
            _storyDict[conversation.TalkerType] = conversation.Conversation;
        }
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

    public (CharacterType left, CharacterType right) SetTalker(CharacterType characterType)
    {
        var result = (CharacterType.None, CharacterType.None);
        if (characterType == CharacterType.None) return result;
        _currentInteractor = characterType;
        if (!_storyDict.TryGetValue(_currentInteractor, out var story) || story == null) return result;
        foreach (var s in story.Texts)
        {
            _storyQueue.Enqueue(s);
        }
        result = (story.LeftTalker, story.RightTalker);
        return result;
    }

    public (string text, CurrentTalker position, CharacterType talker) GetText()
    {
        var result = ("これはテストです", CurrentTalker.Narration, CharacterType.None);
        if (_storyQueue.Count <= 0) return result;
        var text = _storyQueue.Dequeue();
        if (_storyQueue.Count <= 0)
            _storyDict[_currentInteractor] = _storyDict.TryGetValue(_currentInteractor, out var story) ? story.NextConversation : null;
        result = (text.Text, text.TalkerType, text.CharacterType);
        return result;
    }
}
