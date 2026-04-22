using MVPTools.Runtime;

/// <summary>インタラクト時のゲームパッドによる選択</summary>
public readonly struct MoveInteractToken : IToken
{
    public readonly SlotMove Move;

    public MoveInteractToken(SlotMove move)
    {
        Move = move;
    }
}