using MVPTools.Runtime;

/// <summary>インタラクト時のゲームパッドによるホットバー選択</summary>
public readonly struct MoveInteractHotbarToken : IToken
{
    public readonly SlotMove Move;

    public MoveInteractHotbarToken(SlotMove move)
    {
        Move = move;
    }
}