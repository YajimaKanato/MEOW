using MVPTools.Runtime;

/// <summary>インタラクト時のキーボードによるホットバーの選択</summary>
public readonly struct SelectInteractHotbarToken : IToken
{
    public readonly int Index;

    public SelectInteractHotbarToken(int index)
    {
        Index = index;
    }
}