using UnityEngine;

public class InteractHotbar : Hotbar
{
    public void GetItem(Sprite item)
    {
        _hotbar[_hotbar.Length - 1]?.SetItem(item);
    }
}
