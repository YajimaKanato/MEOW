using System.Collections.Generic;
using UnityEngine;

public class InteractRuntime
{
    float _textSpeed;
    readonly Dictionary<CharacterType, TalkerData> _characterData = new();
    readonly Dictionary<CharacterType, ConversationAsset> _conversationData = new();

    public InteractRuntime(InteractDefinition definition)
    {
        _textSpeed = definition.TextSpeed;
        foreach (var talker in definition.Talkers)
        {
            _characterData.Add(talker.CharacterType, talker.TalkerData);
            _conversationData.Add(talker.CharacterType, talker.Conversation);
        }
    }
}
