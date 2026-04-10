using MVPTools.Runtime;

/// <summary>文字列を流し始める時のイベントトークン</summary>
public readonly struct StartStreamTextToken : IToken
{
    public readonly CharacterType CharacterType;

    public StartStreamTextToken(CharacterType characterType)
    {
        CharacterType = characterType;
    }
}