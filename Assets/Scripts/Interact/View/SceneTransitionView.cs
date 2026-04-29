using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionView : MonoBehaviour
{
    [SerializeField] Image _fade;
    [SerializeField] float _fadeTime = 0.5f;

    public void FadeIn()
    {
        _fade.DOFade(0, _fadeTime);
    }

    public void SceneTransition(TweenCallback act)
    {
        var s = DOTween.Sequence();
        s.Append(_fade.DOFade(1, _fadeTime));
        s.OnComplete(act);
    }
}
