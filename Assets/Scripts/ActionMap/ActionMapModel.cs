using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionMapModel", menuName = "Model/ActionMapModel")]
public class ActionMapModel : ScriptableObject
{
    [SerializeField] ActionMap _actionMap = ActionMap.Player;

    public ActionMap ActionMap => _actionMap;
}