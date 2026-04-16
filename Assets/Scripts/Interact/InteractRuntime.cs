using MVPTools.Runtime;

public class InteractRuntime : IRuntime
{
    InteractManager _manager;
    TextSpeed _currentTextSpeed;
    int _currentIndex;

    public TextSpeed CurrentTextSpeed => _currentTextSpeed;

    public InteractRuntime(InteractModel definition)
    {
        _currentTextSpeed = definition.TextSpeed;
        _currentIndex = definition.Hotbar.DefaultIndex;
        _manager = new InteractManager(definition.Conversations);
    }

    public void Dispose()
    {

    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public void ChangeTextSpeed(TextSpeed textSpeed)
    {
        _currentTextSpeed = textSpeed;
    }

    public bool SetTalker(CharacterType characterType, out ConversationAsset asset)
    {
        return _manager.SetTalker(characterType, out asset);
    }

    public void UpdateID(CharacterType characterType, int id)
    {
        _manager.UpdateID(characterType, id);
    }

    public void SetKey(ConditionKey conditionKey)
    {
        _manager.SetKey(conditionKey);
    }

    public void RemoveKey(ConditionKey conditionKey)
    {
        _manager.RemoveKey(conditionKey);
    }

    public bool CheckCondition(Branch branch)
    {
        return _manager.CheckCondition(branch);
    }

    public void Clear()
    {
        _manager.Clear();
    }

    public void OpenHotbar()
    {
        _currentIndex = 0;
    }

    public int SelectIndex(int index)
    {
        _currentIndex = index;
        return _currentIndex;
    }

    /// <summary>
    /// ホットバーの次の要素を選択するメソッド
    /// </summary>
    /// <returns>選択したインデックス</returns>
    public int MoveIndex(SlotMove move)
    {
        _currentIndex += (int)move;
        return _currentIndex;
    }
}
