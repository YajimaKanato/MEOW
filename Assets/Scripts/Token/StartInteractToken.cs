using MVPTools.Runtime;

/// <summary>インタラクトを始める時のイベントトークン</summary>
public readonly struct StartInteractToken : IToken
{
    public readonly CharacterType CharacterType;

    public StartInteractToken(CharacterType characterType)
    {
        CharacterType = characterType;
    }
}