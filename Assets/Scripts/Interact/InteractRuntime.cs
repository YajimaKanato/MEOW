using MVPTools.Runtime;

public class InteractRuntime : IRuntime
{
    InteractManager _manager;
    ItemLabel[] _hotbar;
    TextSpeed _currentTextSpeed;
    int _currentIndex;

    public TextSpeed CurrentTextSpeed => _currentTextSpeed;
    public ItemLabel[] Hotbar => _hotbar;

    public InteractRuntime(InteractModel definition)
    {
        _currentTextSpeed = definition.TextSpeed;
        _currentIndex = definition.Hotbar.DefaultIndex;
        _manager = new InteractManager(definition.Conversations);
        var hotbar = definition.Hotbar.Hotbar;
        _hotbar = new ItemLabel[hotbar.Length + 1];
        for (int i = 0; i < _hotbar.Length; i++)
        {
            if (i == _hotbar.Length - 1)
                _hotbar[i] = ItemLabel.None;
            else
                _hotbar[i] = hotbar[i] != null ? hotbar[i].ItemLabel : ItemLabel.None;
        }
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

    public void UpdateHotbar(ItemLabel[] hotbar)
    {
        if (hotbar == null) return;
        for (int i = 0; i < hotbar.Length; i++)
        {
            _hotbar[i] = hotbar[i];
        }
    }

    public bool GetItem(ItemLabel item)
    {
        for (int i = 0; i < _hotbar.Length - 1; i++)
        {
            if (_hotbar[i] == ItemLabel.None)
            {
                _hotbar[i] = item;
                return true;
            }
        }
        _hotbar[_hotbar.Length - 1] = item;
        return false;
    }

    public void ChangeItem()
    {
        var swap = _hotbar[_hotbar.Length - 1];
        _hotbar[_hotbar.Length - 1] = _hotbar[_currentIndex];
        _hotbar[_currentIndex] = swap;
    }
}
