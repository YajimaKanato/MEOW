using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDefinition", menuName = "CharacterDefinition")]
public class CharacterDefinition : ScriptableObject
{
    [SerializeField] CharacterType _characterType;

    public CharacterType characterType => _characterType;
}
