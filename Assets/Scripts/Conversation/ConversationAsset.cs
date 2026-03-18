using UnityEngine;

[CreateAssetMenu(fileName = "ConversationAsset", menuName = "Conversation/ConversationAsset")]
public class ConversationAsset : ScriptableObject
{
    [SerializeField] ConversationType _conversationType;
    [SerializeField, TextArea] string[] _texts;
    [SerializeField] ConversationAsset _nextConversation;

    public ConversationType ConversationType => _conversationType;
    public string[] Texts => _texts;
    public ConversationAsset NextConversation => _nextConversation;
}
