using MVPTools.Runtime;
using UnityEngine;

public class DropItemPresenter : InteractablePresenter
{
    public DropItemPresenter(DropItemView view, InteractableModel model) : base(view, model)
    {
        if (!RuntimeStorage.TryGetData<DropItemRuntime>(view.ID, out var data))
        {
            _runtime = new DropItemRuntime(model);
            RuntimeStorage.RegisterData(view.ID, _runtime);
        }
        else
        {
            _runtime = data;
        }
    }

    public void SetItem(ItemLabel item)
    {
        (_runtime as DropItemRuntime)?.SetItem(item);
    }
}