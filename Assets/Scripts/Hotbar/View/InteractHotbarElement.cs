using UnityEngine;

public class InteractHotbarElement : HotbarElement
{
    [SerializeField] Sprite _select;
    [SerializeField] Sprite _unselect;

    public override void Select()
    {
        if (!_frame) return;
        _frame.sprite = _select;
        _frame.color = Color.red;
    }

    public override void Unselect()
    {
        if (!_frame) return;
        _frame.sprite = _unselect;
        _frame.color = Color.green;
    }
}
