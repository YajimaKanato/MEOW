using MVPTools.Runtime;

public class PlayerRuntime : IRuntime, IData
{
    ItemLabel[] _hotbar;
    float _walkSpeed;
    float _runSpeed;
    float _jumpPower;
    int _currentIndex = 0;
    bool _isRunnig;
    bool _isGround;
    bool _isFalling;

    public ItemLabel[] Hotbar => _hotbar;
    public float JumpPower => _jumpPower;
    public bool IsGround => _isGround;
    public bool IsFalling => _isFalling;

    public string ID { get; private set; }

    public PlayerRuntime(PlayerModel model)
    {
        var hotbar = model.Hotbar.Hotbar;
        _hotbar = new ItemLabel[hotbar.Length];
        EventBus.Publish(new SetFlagToken(ConditionKey.HotbarIsFullness));
        for (int i = 0; i < hotbar.Length; i++)
        {
            _hotbar[i] = hotbar[i] != null ? hotbar[i].ItemLabel : ItemLabel.None;
            if (_hotbar[i] != ItemLabel.None)
                EventBus.Publish(new SetFlagToken(ConditionKey.HaveAnyFood));
            else
                EventBus.Publish(new RemoveFlagToken(ConditionKey.HotbarIsFullness));
        }
        _walkSpeed = model.WalkSpeed;
        _runSpeed = model.RunSpeed;
        _jumpPower = model.JumpPower;
        ID = model.ID;
    }

    public void Dispose()
    {

    }

    public void Initialize()
    {

    }

    public void Run(bool isRunning)
    {
        if (_isGround) _isRunnig = isRunning;
    }

    public float GetMoveSpeed()
    {
        return _isRunnig ? _runSpeed : _walkSpeed;
    }

    public void Ground(bool isGround)
    {
        _isGround = isGround;
    }

    public void Down(bool isFalling)
    {
        if (_isGround) _isFalling = isFalling;
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

    public bool ValidateGetItem(out int index)
    {
        index = -1;
        for (int i = 0; i < _hotbar.Length; i++)
        {
            if (_hotbar[i] == ItemLabel.None)
            {
                index = i;
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// アイテムを獲得するメソッド
    /// </summary>
    /// <param name="item">獲得したアイテム</param>
    /// <param name="index">格納するインデックス</param>
    /// <returns>交換したアイテム</returns>
    public ItemLabel GetItem(ItemLabel item, int index)
    {
        if (index > _hotbar.Length - 1) return item;
        var returnItem = _hotbar[index];
        _hotbar[index] = item;
        return returnItem;
    }

    /// <summary>
    /// アイテムを使用するメソッド
    /// </summary>
    /// <returns>使用したアイテム</returns>
    public ItemLabel UseItem()
    {
        if (_currentIndex > _hotbar.Length - 1 || _currentIndex < 0) return ItemLabel.None;
        var item = _hotbar[_currentIndex];
        _hotbar[_currentIndex] = ItemLabel.None;
        return item;
    }
}