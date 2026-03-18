using UnityEngine;

[CreateAssetMenu(fileName = "NextConversationAsset", menuName = "Conversation/NextConversationAsset")]
public class NextConversationAsset : ConversationAsset
{
    [SerializeField] ConversationAsset _nextConversation;

    public ConversationAsset NextConversation => _nextConversation;
}
