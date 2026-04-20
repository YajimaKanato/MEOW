using MVPTools.Runtime;

public class DropItemRuntime : InteractableRuntime
{
    public DropItemRuntime(InteractableModel model) : base(model)
    {
    }

    public void SetItem(ItemLabel item)
    {
        _item = item;
    }
}