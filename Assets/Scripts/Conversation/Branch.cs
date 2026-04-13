using UnityEngine;

[CreateAssetMenu(fileName = "Branch", menuName = "Conversation/Branch")]
public class Branch : ScriptableObject
{
    [SerializeField] ConditionNode _condition;
    [SerializeField] ConversationAsset _next;
}
