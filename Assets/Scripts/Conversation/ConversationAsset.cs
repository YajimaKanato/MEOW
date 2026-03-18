using System;
using UnityEngine;

public abstract class ConversationAsset : ScriptableObject
{
    [SerializeField] Talker[] _texts;

    public Talker[] Texts => _texts;
}

[Serializable]
public struct Talker
{
    [SerializeField] CharacterType _talkerType;
    [SerializeField, TextArea] string _text;

    public CharacterType TalkerType => _talkerType;
    public string Text => _text;
}