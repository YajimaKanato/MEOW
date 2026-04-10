using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionMapModel", menuName = "Model/ActionMapModel")]
public class ActionMapModel : ScriptableObject, IModel<ActionMapRuntime>
{
    [SerializeField] ActionMap _actionMap = ActionMap.Player;

    public ActionMap ActionMap => _actionMap;

    public ActionMapRuntime CreateRuntime()
    {
        return new ActionMapRuntime(this);
    }
}