using UnityEngine;
using UnityEngine.UI;

public abstract class HotbarElement : MonoBehaviour
{
    [SerializeField] protected Image _item;
    [SerializeField] protected Image _frame;

    public void GetItem(Sprite sprite)
    {
        if (!_item) return;
        _item.sprite = sprite;
    }

    public void UseItem()
    {
        if (!_item) return;
        _item.sprite = null;
    }

    public abstract void Select();

    public abstract void Unselect();
}
