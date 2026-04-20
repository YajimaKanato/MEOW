using MVPTools.Runtime;
using UnityEngine;

public partial class DropItemView : InteractableView
{
    public override void Initialize()
    {
        base.Initialize();
        _presenter = new DropItemPresenter(this, _model);
        transform.SetParent(null);
    }
}
