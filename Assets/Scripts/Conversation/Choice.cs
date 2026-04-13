using UnityEngine;

[CreateAssetMenu(fileName = "Choice", menuName = "Conversation/Choice")]
public class Choice : ScriptableObject
{
    [Header("画面に表示するテキスト"), SerializeField] string _conditionText;
    [SerializeField] ConditionNode _condition;
    [SerializeField] ConversationAsset _next;
}
