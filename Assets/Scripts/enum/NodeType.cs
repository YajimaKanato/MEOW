using UnityEngine;

public enum NodeType
{
    [InspectorName("単体条件")] Leaf,
    [InspectorName("かつ")] And,
    [InspectorName("または")] Or,
    [InspectorName("でなければ")] Not
}
