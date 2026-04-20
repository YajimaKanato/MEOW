using DG.Tweening;
using MVPTools.Runtime;
using UnityEngine;

public partial class InteractableView
{
    [SerializeField] DropItemView _dropItem;
    //Viewの表示部分を実装
    public void Selected()
    {
        transform.DOScale(Vector2.one * 1.1f, 0.3f);
    }

    public void Unselected()
    {
        transform.DOScale(1, 0.3f);
    }

    public void DropItem(ItemLabel item)
    {
        var active = item != ItemLabel.None;
        _dropItem?.gameObject?.SetActive(active);
        if (active) _dropItem?.SetItem(item);
    }
}