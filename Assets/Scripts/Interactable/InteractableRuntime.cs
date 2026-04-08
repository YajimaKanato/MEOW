using MVPTools.Runtime;

public class InteractableRuntime : IRuntime
{
    CharacterType _characterType;

    public CharacterType CharacterType => _characterType;

    public InteractableRuntime(InteractableModel model)
    {
        _characterType = model.CharacterType;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }
}