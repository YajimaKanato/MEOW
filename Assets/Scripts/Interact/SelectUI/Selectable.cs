using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField] SelectableElement[] _elements;
    int _currentIndex;

    public void SetElements(Sprite icon, string text,int index)
    {
        _elements[index]?.SetChoice(icon, text);
    }

    public void SelectIndex(int index)
    {
        _elements[_currentIndex]?.Unselect();
        _elements[index]?.Select();
        _currentIndex = index;
    }
}
