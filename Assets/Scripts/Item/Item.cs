using UnityEngine;

public enum ItemType
{
    GoodFood,
    BadFood,
    KeyItem,
    Invalid
}

public enum ItemLabel
{
    [InspectorName("肉")] Meat,
    [InspectorName("チーズ")] Cheese,
    [InspectorName("魚")] Fish,
    [InspectorName("腐った肉")] RottenMeat,
    [InspectorName("毒魚")] RottenFish,
    [InspectorName("チョコ")] Chocolate,
    [InspectorName("お酒")] Alcohol,
    [InspectorName("犬の首輪")] DogCollar,
    [InspectorName("ロープ")] Rope,
    [InspectorName("倉庫のキー")] StorageKey,
    [InspectorName("メモリーカード")] MemoryCard,
    [InspectorName("アンドロイドの内蔵カード")] AndroidCard,
    None
}
