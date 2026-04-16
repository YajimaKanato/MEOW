using UnityEngine;

[CreateAssetMenu(fileName = "ConvesationList", menuName = "Conversation/ConvesationList")]
public class ConversationList : ScriptableObject
{
    [SerializeField] CharacterType _talkerType;
    [SerializeField] int _startID;
    [SerializeField] ConversationAsset[] _startConversations;

    public CharacterType TalkerType => _talkerType;
    public int StartID => _startID;
    public ConversationAsset[] Conversations => _startConversations;

#if UNITY_EDITOR
    public void SetConversation(ConversationAsset[] assets)
    {
        _startConversations = assets;
    }
#endif
}
