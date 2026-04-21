using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "Conversation/ConversationAsset")]
public class ConversationAsset : ScriptableObject
{
    [Header("会話ノードの詳細")]
    [SerializeField] CharacterType _characterType;
    [SerializeField] int _id;
    [SerializeField] bool _finish;
    [Header("会話詳細")]
    [SerializeField] Paragraph[] _texts;
    [Header("通常時")]
    [SerializeField] ConversationAsset _default;
    [Header("自動分岐")]
    [SerializeField] Branch[] _branches;
    [Header("選択肢")]
    [SerializeField] Choice[] _choices;

    public CharacterType CharacterType => _characterType;
    public int ID => _id;
    public bool Finish => _finish;
    public Choice[] Choices => _choices;
    public Branch[] Branches => _branches;
    public ConversationAsset Default => _default;
    public Paragraph[] Texts => _texts;
}

[Serializable]
public class Paragraph
{
    [SerializeField] NodeType _nodeType;
    [SerializeField] CharacterType _leftTalker;
    [SerializeField] CharacterType _rightTalker;
    [SerializeField] CurrentTalker _talker;
    [SerializeField, TextArea] string _text;

    public NodeType NodeType => _nodeType;
    public CharacterType LeftTalker => _leftTalker;
    public CharacterType RightTalker => _rightTalker;
    public CurrentTalker TalkerType => _talker;
    public string Text => _text;
}