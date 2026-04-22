using MVPTools.Runtime;

/// <summary>インタラクト時のキーボードによる選択</summary>
public readonly struct SelectInteractToken : IToken
{
    public readonly int Index;

    public SelectInteractToken(int index)
    {
        Index = index;
    }
}