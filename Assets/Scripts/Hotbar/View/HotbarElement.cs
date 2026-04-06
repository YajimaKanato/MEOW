using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HotbarElement : MonoBehaviour
{
    [SerializeField] Image _item;
    [SerializeField] Image _frame;
    [SerializeField] Sprite _select;
    [SerializeField] Sprite _unselect;

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

    public void Select()
    {
        if (!_frame) return;
        _frame.sprite = _select;
        transform.DOScale(1.1f, 0.2f);
    }

    public void Unselect()
    {
        if (!_frame) return;
        _frame.sprite = _unselect;
        transform.DOScale(1, 0.2f);
    }
}
