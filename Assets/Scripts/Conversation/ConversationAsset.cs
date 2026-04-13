using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "Conversation/ConversationAsset")]
public class ConversationAsset : ScriptableObject
{
    [SerializeField] CharacterType _leftTalker;
    [SerializeField] CharacterType _rightTalker;
    [SerializeField] Talker[] _texts;
    [Header("分岐")]
    [SerializeField] Choice[] _choices;
    [SerializeField] Branch[] _branches;
    [Header("通常時")]
    [SerializeField] ConversationAsset _default;

    public CharacterType LeftTalker => _leftTalker;
    public CharacterType RightTalker => _rightTalker;
    public Talker[] Texts => _texts;
    public Choice[] Choices => _choices;
    public Branch[] Branches => _branches;
    public ConversationAsset Default => _default;
}

[Serializable]
public class Talker
{
    [SerializeField] CharacterType _characterType;
    [SerializeField] CurrentTalker _talker;
    [SerializeField, TextArea] string _text;

    public CharacterType CharacterType => _characterType;
    public CurrentTalker TalkerType => _talker;
    public string Text => _text;
}