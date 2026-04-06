using MVPTools.Runtime;
using System.Collections.Generic;
using UnityEngine;

public class InteractRuntime : IRuntime
{
    float _textSpeed;
    readonly Dictionary<CharacterType, TalkerData> _characterData = new();
    readonly Dictionary<CharacterType, ConversationAsset> _conversationData = new();

    public InteractRuntime(InteractModel definition)
    {
        _textSpeed = definition.TextSpeed;
        foreach (var talker in definition.Talkers)
        {
            _characterData.Add(talker.CharacterType, talker.TalkerData);
            _conversationData.Add(talker.CharacterType, talker.Conversation);
        }
    }

    public void Dispose()
    {

    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }
}
