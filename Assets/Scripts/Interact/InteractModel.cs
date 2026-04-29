using MVPTools.Runtime;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractModel", menuName = "Model/InteractModel")]
public class InteractModel : ScriptableObject
{
    [SerializeField] Interactables _interactables;
    [SerializeField] ConversationList[] _conversations;
    [SerializeField] TextSpeed _textSpeed = TextSpeed.Normal;

    public Interactables Interactables => _interactables;
    public ConversationList[] Conversations => _conversations;
    public TextSpeed TextSpeed => _textSpeed;
}