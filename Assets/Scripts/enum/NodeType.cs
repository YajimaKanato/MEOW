using UnityEngine;

public enum NodeType
{
    [InspectorName("会話")] Conversation,
    [InspectorName("二者択一")] Choice,
    [InspectorName("アイテム選択")] ItemSelect,
    [InspectorName("アイテムをあげる")] GiveItem,
    [InspectorName("シーン遷移")] SceneTransition
}
