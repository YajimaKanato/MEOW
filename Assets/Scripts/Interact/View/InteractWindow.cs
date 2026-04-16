using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractWindow : MonoBehaviour
{
    [SerializeField] Image _leftFilter;
    [SerializeField] Image _leftTalker;
    [SerializeField] Image _rightFilter;
    [SerializeField] Image _rightTalker;
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _talkText;
    [SerializeField] float _performTimeLength = 0.2f;
    [SerializeField, Range(0, 255)] int _filterFadeValue;

    public void ResetWindow()
    {
        var s = DOTween.Sequence();
        s.Join(_leftTalker?.transform.DOScale(1, 0));
        s.Join(_leftFilter?.DOFade(_filterFadeValue / 255f, 0));
        s.Join(_rightTalker?.transform.DOScale(1, 0));
        s.Join(_rightFilter?.DOFade(_filterFadeValue / 255f, 0));
        if (_nameText) _nameText.text = "";
        if (_talkText) _talkText.text = "";
    }

    public void SetTalkers(Sprite left, Sprite right)
    {
        if (_leftTalker) _leftTalker.sprite = left;
        if (_rightTalker) _rightTalker.sprite = right;
    }

    public void TalkLeft(string name)
    {
        var s = DOTween.Sequence();
        s.Join(_leftTalker?.transform.DOScale(1.1f, _performTimeLength));
        s.Join(_leftFilter?.DOFade(0, _performTimeLength));
        s.Join(_rightTalker?.transform.DOScale(1, _performTimeLength));
        s.Join(_rightFilter?.DOFade(_filterFadeValue / 255f, _performTimeLength));
        if (_nameText) _nameText.text = name;
    }

    public void TalkRight(string name)
    {
        var s = DOTween.Sequence();
        s.Join(_rightTalker?.transform.DOScale(1.1f, _performTimeLength));
        s.Join(_rightFilter?.DOFade(0, _performTimeLength));
        s.Join(_leftTalker?.transform.DOScale(1, _performTimeLength));
        s.Join(_leftFilter?.DOFade(_filterFadeValue / 255f, _performTimeLength));
        if (_nameText) _nameText.text = name;
    }

    public void TalkNarration()
    {
        var s = DOTween.Sequence();
        s.Join(_leftTalker?.transform.DOScale(1, _performTimeLength));
        s.Join(_leftFilter?.DOFade(_filterFadeValue / 255f, _performTimeLength));
        s.Join(_rightTalker?.transform.DOScale(1, _performTimeLength));
        s.Join(_rightFilter?.DOFade(_filterFadeValue / 255f, _performTimeLength));
        if (_nameText) _nameText.text = "";
    }

    public void UpdateTalkText(string text)
    {
        if (_talkText) _talkText.text = text;
    }
}
