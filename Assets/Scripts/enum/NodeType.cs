using UnityEngine;

public enum NodeType
{
    [InspectorName("会話")] Conversation,
    [InspectorName("選択肢")] Choice,
    [InspectorName("アイテムをあげる")] GiveItem
}
