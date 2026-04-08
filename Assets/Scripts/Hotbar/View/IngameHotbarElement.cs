using DG.Tweening;
using UnityEngine;

public class IngameHotbarElement : HotbarElement
{
    public override void Select()
    {
        if (!_frame) return;
        transform.DOScale(1.1f, 0.2f);
    }

    public override void Unselect()
    {
        if (!_frame) return;
        transform.DOScale(1, 0.2f);
    }
}
