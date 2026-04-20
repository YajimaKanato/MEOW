using MVPTools.Runtime;

/// <summary>インタラクトを始める時のイベントトークン</summary>
public readonly struct StartInteractToken : IToken
{
    public readonly string ID;
    public readonly CharacterType CharacterType;

    public StartInteractToken(string id, CharacterType characterType)
    {
        ID = id;
        CharacterType = characterType;
    }
}