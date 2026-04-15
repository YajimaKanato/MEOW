using UnityEngine;

[CreateAssetMenu(fileName = "Branch", menuName = "Conversation/Branch")]
public class Branch : ScriptableObject
{
    [SerializeField] ConditionNode[] _conditions;
    [SerializeField] ConversationAsset _next;

    public ConditionNode[] Conditions => _conditions;
    public ConversationAsset Next => _next;
}
