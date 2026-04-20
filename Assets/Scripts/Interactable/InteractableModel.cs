using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableModel", menuName = "Model/InteractableModel")]
public class InteractableModel : ScriptableObject
{
    [SerializeField] CharacterType _characterType;
    [SerializeField] int _chapter;
    [SerializeField] string _characterName;
    [SerializeField] Sprite _talkingSprite;
    [SerializeField] ItemBase _item;

    public CharacterType CharacterType => _characterType;
    public int Chapter => _chapter;
    public string CharacterName => _characterName;
    public Sprite TalkingSprite => _talkingSprite;
    public ItemBase Item => _item;
}