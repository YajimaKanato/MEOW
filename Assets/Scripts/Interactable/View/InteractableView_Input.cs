using MVPTools.Runtime;
using UnityEngine;

public partial class InteractableView
{
    //必要な場合にViewの入力部分を実装
    public void GetCharacterType()
    {
        _presenter?.GetCharacterType();
    }
}