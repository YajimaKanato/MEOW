using UnityEngine;

[CreateAssetMenu(fileName = "Choice", menuName = "Conversation/Choice")]
public class Choice : ScriptableObject
{
    [Header("画面に表示するテキスト"), SerializeField] string _conditionText;
    [Header("立てるフラグ"), SerializeField] ConditionKey _conditionKey;
    [SerializeField] ConversationAsset _next;

    public string ConditionText => _conditionText;
    public ConditionKey ConditionKey => _conditionKey;
    public ConversationAsset Next => _next;
}
