using UnityEngine;

public class Hotbar : MonoBehaviour
{
    [SerializeField] protected HotbarElement[] _hotbar;
    int _currentIndex = 0;

    public void OpenHotbar(Sprite[] sprites, int index)
    {
        _currentIndex = index;
        for (int i = 0; i < sprites.Length; i++)
        {
            _hotbar[i].SetItem(sprites[i]);
            if (i == _currentIndex)
                _hotbar[i].Select();
            else
                _hotbar[i].Unselect();
        }
    }

    public void ChangeSlot(int index)
    {
        if (index < 0 || _hotbar.Length - 1 < index) return;
        _hotbar[_currentIndex]?.Unselect();
        _hotbar[index]?.Select();
        _currentIndex = index;
    }
}
