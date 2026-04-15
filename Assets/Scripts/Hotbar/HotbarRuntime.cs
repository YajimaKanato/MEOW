using MVPTools.Runtime;

public class HotbarRuntime : IRuntime
{
    int _currentIndex = 0;

    public int CurrentIndex => _currentIndex;

    public HotbarRuntime(HotbarModel model)
    {
        _currentIndex = model.DefaultIndex;
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
}