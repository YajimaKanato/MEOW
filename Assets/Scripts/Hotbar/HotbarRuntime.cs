using MVPTools.Runtime;

public class HotbarRuntime : IRuntime
{
    ItemLabel[] _hotbar;
    int _currentIndex = 0;
    int _indexForInteract = 0;

    public ItemLabel[] Hotbar => _hotbar;

    public HotbarRuntime(HotbarModel model)
    {
        var hotbar = model.Hotbar;
        _hotbar = new ItemLabel[hotbar.Length];
        for (int i = 0; i < hotbar.Length; i++)
        {
            var item = hotbar[i];
            _hotbar[i] = item == null ? ItemLabel.None : item.ItemLabel;
        }
    }

    public void Dispose()
    {

    }

    public void Initialize()
    {

    }

    public int SelectIndex(int index)
    {
        if (index > _hotbar.Length - 1) return -1;
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
        if (_currentIndex > _hotbar.Length - 1) _currentIndex = 0;
        if (_currentIndex < 0) _currentIndex = _hotbar.Length - 1;
        return _currentIndex;
    }

    /// <summary>
    /// アイテム獲得が成功したかどうかを判定するメソッド
    /// </summary>
    /// <returns>成功したかどうか、成功した場合にアイテムを格納できるインデックス</returns>
    public (bool gotItem, int index) ValidateGetItem()
    {
        if (_currentIndex > _hotbar.Length - 1 || _currentIndex < 0) return (false, -1);
        for (int i = 0; i < _hotbar.Length; i++)
        {
            if (_hotbar[i] == ItemLabel.None) return (true, i);
        }
        return (false, -1);
    }

    /// <summary>
    /// アイテムを獲得するメソッド
    /// </summary>
    /// <param name="item">獲得したアイテム</param>
    /// <param name="index">格納するインデックス</param>
    /// <returns>交換したアイテム</returns>
    public ItemLabel GetItem(ItemLabel item, int index)
    {
        if (item == ItemLabel.None) return ItemLabel.None;
        if (index > _hotbar.Length - 1 || index < 0) return ItemLabel.None;
        var dropItem = _hotbar[index];
        _hotbar[index] = item;
        return dropItem;
    }

    /// <summary>
    /// アイテムを使用するメソッド
    /// </summary>
    /// <returns>使用したアイテムとそのインデックス</returns>
    public (ItemLabel item, int index) UseItem()
    {
        if (_currentIndex > _hotbar.Length - 1 || _currentIndex < 0) return (ItemLabel.None, -1);
        var item = _hotbar[_currentIndex];
        _hotbar[_currentIndex] = ItemLabel.None;
        return (item, _currentIndex);
    }

    public void OpenInteractHotbar()
    {
        _indexForInteract = 0;
    }

    public int SelectInteractIndex(int index)
    {
        if (index > _hotbar.Length - 1) return -1;
        _indexForInteract = index;
        return _indexForInteract;
    }

    /// <summary>
    /// ホットバーの次の要素を選択するメソッド
    /// </summary>
    /// <returns>選択したインデックス</returns>
    public int MoveInteractIndex(SlotMove move)
    {
        _indexForInteract += (int)move;
        if (_indexForInteract > _hotbar.Length - 1) _indexForInteract = 0;
        if (_indexForInteract < 0) _indexForInteract = _hotbar.Length - 1;
        return _indexForInteract;
    }

    public (ItemLabel item, int index) GiveItem()
    {
        if (_indexForInteract > _hotbar.Length - 1 || _indexForInteract < 0) return (ItemLabel.None, -1);
        var item = _hotbar[_indexForInteract];
        _hotbar[_indexForInteract] = ItemLabel.None;
        return (item, _indexForInteract);
    }
}