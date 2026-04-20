using MVPTools.Runtime;
using UnityEngine;

public class DropItemPresenter : InteractablePresenter
{
    public DropItemPresenter(DropItemView view, InteractableModel model) : base(view, model)
    {
        if (!RuntimeStorage.TryGetData(view.ID, out var data) || !(data is DropItemRuntime typed))
        {
            _runtime = new DropItemRuntime(model);
            RuntimeStorage.RegisterData(view.ID, _runtime);
        }
        else
        {
            _runtime = typed;
        }
    }

    public void SetItem(ItemLabel item)
    {
        (_runtime as DropItemRuntime)?.SetItem(item);
    }
}