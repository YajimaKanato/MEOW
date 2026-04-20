using UnityEngine;

public enum ConditionKey
{
    [InspectorName("食料を持っている")] HaveAnyFood,
    [InspectorName("食料を持っていない")] HaveNoFood,
    [InspectorName("犬が食料を受け取る")] DogGetsAnyFood,
}
