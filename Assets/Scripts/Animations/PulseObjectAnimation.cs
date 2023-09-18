using DG.Tweening;
using UnityEngine;

public class PulseObjectAnimation : MonoBehaviour
{
    [SerializeField] private float pulseDuration;
    [SerializeField] private float pulseScale;

    private Sequence _animationSequence;

    private void OnEnable()
    {
        _animationSequence = DOTween.Sequence();
        _animationSequence.Append(AnimationScale());
    }

    private void OnDisable() => _animationSequence.Kill();

    private Tween AnimationScale()
    {      
        return transform.DOScale(pulseScale, pulseDuration)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
    }
}
