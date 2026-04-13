using System;
using UnityEngine;

[Serializable]
public class ConditionNode
{
    [Header("条件の種類"), SerializeField] ConditionType _conditionType;
    [Header("分岐ノードの種類"), SerializeField] NodeType _nodeType = NodeType.Leaf;
    [Header("具体的な条件"), SerializeField] ConditionKey _conditionKey;

    public ConditionType ConditionType => _conditionType;
    public ConditionKey ConditionKey => _conditionKey;

    public bool Check()
    {
        return _nodeType switch
        {
            NodeType.Leaf => true,
            NodeType.And => true,
            NodeType.Or => true,
            NodeType.Not => true,
            _ => false,
        };
    }
}
