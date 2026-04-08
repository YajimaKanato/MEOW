using UnityEngine;

public class InteractHotbarElement : HotbarElement
{
    [SerializeField] Sprite _select;
    [SerializeField] Sprite _unselect;

    public override void Select()
    {
        if (!_frame) return;
        _frame.sprite = _select;
    }

    public override void Unselect()
    {
        if (!_frame) return;
        _frame.sprite = _unselect;
    }
}
