using MVPTools.Runtime;

public class HotbarRuntime : IRuntime
{
    int _currentIndex = 0;
    ItemLabel[] _hotbar;

    public int CurrentIndex => _currentIndex;
    public ItemLabel[] Hotbar => _hotbar;

    public HotbarRuntime(HotbarModel model)
    {
        _currentIndex = model.DefaultIndex;
        var hotbar = model.Hotbar;
        _hotbar = new ItemLabel[hotbar.Length];
        for (int i = 0; i < hotbar.Length; i++)
        {
            if (hotbar[i] == null) continue;
            _hotbar[i] = hotbar[i].ItemLabel;
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
}