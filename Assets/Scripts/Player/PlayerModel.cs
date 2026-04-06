using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerModel", menuName = "Model/PlayerModel")]
public class PlayerModel : ScriptableObject, IModel<PlayerRuntime>
{
    [SerializeField, Min(0.1f)] float _walkSpeed = 5;
    [SerializeField, Min(0.1f)] float _runSpeed = 7;
    [SerializeField, Min(0.1f)] float _jumpPower = 5;

    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float JumpPower => _jumpPower;

    public PlayerRuntime CreateRuntime()
    {
        return new PlayerRuntime(this);
    }
}