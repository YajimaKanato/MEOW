using UnityEngine;

[CreateAssetMenu(fileName = "GoodFood", menuName = "Item/GoodFood")]
public class GoodFood : ItemBase
{
    [Header("アイテムの効果")]
    [SerializeField, Min(0)] int _saturate;

    public int Saturate => _saturate;
}
