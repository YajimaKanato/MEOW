using System;
using UnityEngine;

[Serializable]
public class ConditionNode
{
    [Header("条件の種類"), SerializeField] ConditionType _conditionType;
    [Header("具体的な条件"), SerializeField] ConditionKey _conditionKey;

    public ConditionType ConditionType => _conditionType;
    public ConditionKey ConditionKey => _conditionKey;
}
