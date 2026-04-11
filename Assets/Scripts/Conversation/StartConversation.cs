using UnityEngine;

[CreateAssetMenu(fileName = "ConvesationList", menuName = "Conversation/ConvesationList")]
public class StartConversation : ScriptableObject
{
    [SerializeField] CharacterType _talkerType;
    [SerializeField] ConversationAsset _startConversation;

    public ConversationAsset Conversation => _startConversation;
    public CharacterType TalkerType => _talkerType;
}
