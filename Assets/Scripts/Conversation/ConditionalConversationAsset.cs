using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ConditionalConversationAsset", menuName = "Conversation/ConditionalConversationAsset")]
public class ConditionalConversationAsset : ConversationAsset
{
    [SerializeField] ConditionalConversation[] _conditionalConversations;
    [SerializeField] ConversationAsset _defaultNextConversation;

    public ConditionalConversation[] ConditionalConversations => _conditionalConversations;
    public ConversationAsset DefaultNextConversation => _defaultNextConversation;
}

[Serializable]
public struct ConditionalConversation
{
    [SerializeField] ConversationAsset _nextConversation;

    public ConversationAsset NextConversation => _nextConversation;
}