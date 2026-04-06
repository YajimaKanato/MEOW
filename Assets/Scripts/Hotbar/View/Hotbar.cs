using UnityEngine;

public class Hotbar : MonoBehaviour
{
    [SerializeField] HotbarElement[] _hotbar;
    [SerializeField] CanvasGroup _canvasGroup;
    int _currentIndex = 0;

    public void OpenHotbar(Sprite[] sprites)
    {
        _currentIndex = 0;
        for (int i = 0; i < _hotbar.Length; i++)
        {
            _hotbar[i].GetItem(sprites[i]);
            if (i == _currentIndex)
                _hotbar[i].Select();
            else
                _hotbar[i].Unselect();
        }
        if (_canvasGroup) _canvasGroup.alpha = 1;
    }

    public void CloseHotbar()
    {
        if (_canvasGroup) _canvasGroup.alpha = 0;
    }

    public void ChangeSlot(int index)
    {
        _hotbar[_currentIndex]?.Unselect();
        _hotbar[index]?.Select();
        _currentIndex = index;
    }

    public void UseItem(int index)
    {
        _hotbar[index]?.UseItem();
    }

    public void GetItem(Sprite sprite, int index)
    {
        _hotbar[index]?.GetItem(sprite);
    }
}
