using MVPTools.Runtime;

/// <summary>インゲーム時のゲームパッドによるホットバー選択</summary>
public readonly struct MoveIngameHotbarToken : IToken
{
    public readonly SlotMove Move;

    public MoveIngameHotbarToken(SlotMove move)
    {
        Move = move;
    }
}