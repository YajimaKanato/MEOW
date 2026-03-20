using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDefinition", menuName = "Definition/CharacterDefinition")]
public class CharacterDefinition : ScriptableObject
{
    [SerializeField] CharacterType _characterType;

    public CharacterType characterType => _characterType;
}
