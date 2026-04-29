using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField] SelectableElement[] _elements;
    int _currentIndex;

    public void OpenSelectable()
    {
        for (int i = 0; i < _elements.Length; i++)
        {
            if (i == 0)
                _elements[i]?.Select();
            else
                _elements[i]?.Unselect();
        }
        _currentIndex = 0;
    }

    public void SetElements(Sprite icon, string text, int index)
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
