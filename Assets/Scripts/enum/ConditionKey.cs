using UnityEngine;

public enum ConditionKey
{
    [InspectorName("フラグなし")] None,
    [InspectorName("食料を持っている")] HaveAnyFood,
    [InspectorName("犬が食料を受け取る")] DogGetsAnyFood,
    [InspectorName("アイテムがいっぱい")] HotbarIsFullness,
    [InspectorName("シーン遷移")] SceneTransition
}
