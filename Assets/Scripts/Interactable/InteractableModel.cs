using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableModel", menuName = "Model/InteractableModel")]
public class InteractableModel : ScriptableObject, IModel<InteractableRuntime>
{
    [SerializeField] CharacterType _characterType;
    [SerializeField] string _characterName;
    [SerializeField] Sprite _talkingSprite;
    [SerializeField] Sprite _silentSprite;

    public CharacterType CharacterType => _characterType;
    public string CharacterName => _characterName;
    public Sprite TalkingSprite => _talkingSprite;
    public Sprite SilentSprite => _silentSprite;

    public InteractableRuntime CreateRuntime()
    {
        return new InteractableRuntime(this);
    }
}