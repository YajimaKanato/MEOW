using UnityEngine;

[CreateAssetMenu(fileName = "BadFood", menuName = "Item/BadFood")]
public class BadFood : ItemBase
{
    [Header("アイテムの効果")]
    [SerializeField, Min(0)] int _saturate;
    [SerializeField, Min(0)] int _damage;

    public int Saturate => _saturate;
    public int Damage => _damage;
}
