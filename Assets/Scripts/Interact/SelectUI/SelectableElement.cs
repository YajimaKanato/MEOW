using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectableElement : MonoBehaviour
{
    [SerializeField] Image _icon;
    [SerializeField] TextMeshProUGUI _text;

    public void SetChoice(Sprite icon, string text)
    {
        if (_icon != null) _icon.sprite = icon;
        if (_text != null) _text.text = text;
    }

    public void Select()
    {

    }

    public void Unselect()
    {

    }
}
