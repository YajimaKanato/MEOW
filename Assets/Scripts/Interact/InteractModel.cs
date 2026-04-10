using MVPTools.Runtime;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractModel", menuName = "Model/InteractModel")]
public class InteractModel : ScriptableObject, IModel<InteractRuntime>
{
    [SerializeField] Interactables _interactables;
    [SerializeField] TextSpeed _textSpeed = TextSpeed.Normal;

    public Interactables Interactables => _interactables;
    public TextSpeed TextSpeed => _textSpeed;

    public InteractRuntime CreateRuntime()
    {
        return new InteractRuntime(this);
    }
}

[Serializable]
public struct TalkerType
{
    [SerializeField] CharacterType _characterType;
    [SerializeField] TalkerData _talkerData;
    [SerializeField] ConversationAsset _conversation;

    public CharacterType CharacterType => _characterType;
    public TalkerData TalkerData => _talkerData;
    public ConversationAsset Conversation => _conversation;
}

[Serializable]
public struct TalkerData
{
    [SerializeField] string _name;
    [SerializeField] Sprite _sprite;

    public string Name => _name;
    public Sprite Sprite => _sprite;
}