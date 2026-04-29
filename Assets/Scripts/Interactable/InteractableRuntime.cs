using MVPTools.Runtime;

public class InteractableRuntime : IRuntime
{
    CharacterType _characterType;
    protected ItemLabel _item;
    protected SceneName _sceneName;

    public CharacterType CharacterType => _characterType;
    public ItemLabel Item => _item;
    public SceneName SceneName => _sceneName;

    public InteractableRuntime(InteractableModel model)
    {
        _characterType = model.CharacterType;
        _item = model?.Item != null ? model.Item.ItemLabel : ItemLabel.None;
        _sceneName = model.SceneName;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }
}