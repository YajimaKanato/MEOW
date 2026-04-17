using UnityEngine;
using UnityEngine.UI;

public abstract class HotbarElement : MonoBehaviour
{
    [SerializeField] protected Image _item;
    [SerializeField] protected Image _frame;

    public void SetItem(Sprite sprite)
    {
        if (!_item) return;
        _item.sprite = sprite;
    }

    public abstract void Select();

    public abstract void Unselect();
}
