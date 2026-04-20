using MVPTools.Runtime;

public class InteractableRuntime : IRuntime
{
    CharacterType _characterType;
    protected ItemLabel _item;

    public CharacterType CharacterType => _characterType;
    public ItemLabel Item => _item;

    public InteractableRuntime(InteractableModel model)
    {
        _characterType = model.CharacterType;
        _item = model?.Item != null ? model.Item.ItemLabel : ItemLabel.None;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }
}