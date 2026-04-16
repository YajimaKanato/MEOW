using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "Conversation/ConversationAsset")]
public class ConversationAsset : ScriptableObject
{
    [Header("会話ノードの種類")]
    [SerializeField] CharacterType _characterType;
    [SerializeField] int _id;
    [SerializeField] NodeType _nodeType = NodeType.Conversation;
    [SerializeField] bool _finish;
    [Header("選択肢")]
    [SerializeField] ChoiceType _choiceType = ChoiceType.None;
    [SerializeField] Choice[] _choices;
    [Header("自動分岐")]
    [SerializeField] Branch[] _branches;
    [Header("通常時")]
    [SerializeField] ConversationAsset _default;
    [Header("会話詳細")]
    [SerializeField] Talker[] _texts;
    [SerializeField] ItemBase _item;

    public CharacterType CharacterType => _characterType;
    public int ID => _id;
    public NodeType NodeType => _nodeType;
    public bool Finish => _finish;
    public ChoiceType ChoiceType => _choiceType;
    public Choice[] Choices => _choices;
    public Branch[] Branches => _branches;
    public ConversationAsset Default => _default;
    public Talker[] Texts => _texts;
    public ItemBase Item => _item;
}

[Serializable]
public class Talker
{
    [SerializeField] CharacterType _leftTalker;
    [SerializeField] CharacterType _rightTalker;
    [SerializeField] CurrentTalker _talker;
    [SerializeField, TextArea] string _text;

    public CharacterType LeftTalker => _leftTalker;
    public CharacterType RightTalker => _rightTalker;
    public CurrentTalker TalkerType => _talker;
    public string Text => _text;
}