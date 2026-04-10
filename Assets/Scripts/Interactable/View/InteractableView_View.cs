using DG.Tweening;
using MVPTools.Runtime;
using UnityEngine;

public partial class InteractableView
{
    //Viewの表示部分を実装
    public void Selected()
    {
        transform.DOScale(Vector2.one * 1.1f, 0.3f);
    }

    public void Unselected()
    {
        transform.DOScale(1, 0.3f);
    }
}