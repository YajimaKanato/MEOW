using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInteractModel", menuName = "Model/PlayerInteractModel")]
public class PlayerInteractModel : ScriptableObject, IModel<PlayerInteractRuntime>
{
    public PlayerInteractRuntime CreateRuntime()
    {
        return new PlayerInteractRuntime(this);
    }
}