using MVPTools.Runtime;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractModel", menuName = "Model/InteractModel")]
public class InteractModel : ScriptableObject, IModel<InteractRuntime>
{
    [SerializeField, Min(0.1f)] float _textSpeed;
    [SerializeField] TalkerType[] _talkers;

    public float TextSpeed => _textSpeed;
    public TalkerType[] Talkers => _talkers;

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