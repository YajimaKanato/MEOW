using UnityEngine;

[CreateAssetMenu(fileName = "Interactables", menuName = "Model/Interactables")]
public class Interactables : ScriptableObject
{
    [SerializeField] InteractableModel[] _interactableList;

    public InteractableModel[] InteractableList => _interactableList;
}
