using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetItemWindow : MonoBehaviour
{
    [SerializeField] Image _newTag;
    [SerializeField] Image _itemIcon;
    [SerializeField] TextMeshProUGUI _itemName;
    [SerializeField] TextMeshProUGUI _itemInfo;

    public void GetItem(Sprite icon, string name, string info, bool isNew)
    {
        if (isNew) _newTag.enabled = true;
        if (_itemIcon != null) _itemIcon.sprite = icon;
        if (_itemName != null) _itemName.text = name;
        if (_itemInfo != null) _itemInfo.text = info;
    }
}
