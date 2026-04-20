using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerModel", menuName = "Model/PlayerModel")]
public class PlayerModel : ScriptableObject, IData
{
    [SerializeField, Min(0.1f)] float _walkSpeed = 5;
    [SerializeField, Min(0.1f)] float _runSpeed = 7;
    [SerializeField, Min(0.1f)] float _jumpPower = 5;
    [SerializeField] HotbarModel _hotbar;


    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float JumpPower => _jumpPower;
    public HotbarModel Hotbar => _hotbar;

    public string ID => CharacterType.Player.ToString();
}