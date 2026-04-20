using MVPTools.Runtime;
using UnityEngine;

public partial class DropItemView
{
    //必要な場合にViewの入力部分を実装
    public void SetItem(ItemLabel label)
    {
        if (_presenter != null && _presenter is DropItemPresenter typed)
            ((DropItemPresenter)_presenter).SetItem(label);
    }
}