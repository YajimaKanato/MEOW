using MVPTools.Runtime;

/// <summary>インゲーム時のキーボードによるホットバー選択</summary>
public readonly struct SelectIngameHotbarToken : IToken
{
    public readonly int Index;

    public SelectIngameHotbarToken(int index)
    {
        Index = index;
    }
}