using MVPTools.Runtime;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractModel", menuName = "Model/InteractModel")]
public class InteractModel : ScriptableObject, IModel<InteractRuntime>
{
    [SerializeField] Interactables _interactables;
    [SerializeField] ConversationList[] _conversations;
    [SerializeField] HotbarModel _hotbar;
    [SerializeField] TextSpeed _textSpeed = TextSpeed.Normal;

    public Interactables Interactables => _interactables;
    public ConversationList[] Conversations => _conversations;
    public HotbarModel Hotbar => _hotbar;
    public TextSpeed TextSpeed => _textSpeed;

    public InteractRuntime CreateRuntime()
    {
        return new InteractRuntime(this);
    }
}