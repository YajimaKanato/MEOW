using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "Conversation/ConversationAsset")]
public class ConversationAsset : ScriptableObject
{
    [SerializeField] CharacterType _leftTalker;
    [SerializeField] CharacterType _rightTalker;
    [SerializeField] Talker[] _texts;
    [SerializeField] ConversationAsset _nextConversation;

    public CharacterType LeftTalker => _leftTalker;
    public CharacterType RightTalker => _rightTalker;
    public Talker[] Texts => _texts;
    public ConversationAsset NextConversation => _nextConversation;
}

[Serializable]
public struct Talker
{
    [SerializeField] CharacterType _characterType;
    [SerializeField] CurrentTalker _talker;
    [SerializeField, TextArea] string _text;

    public CharacterType CharacterType => _characterType;
    public CurrentTalker TalkerType => _talker;
    public string Text => _text;
}