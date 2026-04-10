using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractWindow : MonoBehaviour
{
    [SerializeField] Image _leftTalker;
    [SerializeField] Image _rightTalker;
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _talkText;

    public void SetTalkers(Sprite left, Sprite right)
    {
        if (_leftTalker) _leftTalker.sprite = left;
        if (_rightTalker) _rightTalker.sprite = right;
    }

    public void TalkLeft(string name)
    {
        _leftTalker?.transform.DOScale(1.1f, 0.2f);
        _rightTalker?.transform.DOScale(1, 0.2f);
        if (_nameText) _nameText.text = name;
    }

    public void TalkRight(string name)
    {
        _rightTalker?.transform.DOScale(1.1f, 0.2f);
        _leftTalker?.transform.DOScale(1, 0.2f);
        if (_nameText) _nameText.text = name;
    }

    public void UpdateTalkText(string text)
    {
        if (_talkText) _talkText.text = text;
    }
}
