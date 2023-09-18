using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimationMoving : ButtonChangingColorPointing
{
    [SerializeField] private Vector3 startRotationCondition;
    [SerializeField] private Vector3 endRotationCondition;
    [SerializeField] private float durationAnimation;
    [SerializeField] private float sizeUpNumber;
    [SerializeField] private float sizeUpDuration;

    protected Sequence rockSequence;
    protected Sequence pulseSequence;

    protected override void Start()
    {
        base.Start();
        RockAndPulseAnimation();
    }

    public void RockAndPulseAnimation()
    {
        rockSequence = DOTween.Sequence();
        rockSequence.Append(button.transform.DOLocalRotate(startRotationCondition, durationAnimation).SetEase(Ease.InOutSine));
        rockSequence.Append(button.transform.DOLocalRotate(endRotationCondition, durationAnimation).SetEase(Ease.InOutSine));
        rockSequence.SetLoops(-1, LoopType.Yoyo);
        pulseSequence = DOTween.Sequence();
        pulseSequence.Append(button.transform.DOScale(Vector3.one * sizeUpNumber, sizeUpDuration).SetEase(Ease.OutSine));
        pulseSequence.Append(button.transform.DOScale(Vector3.one, sizeUpDuration).SetEase(Ease.OutSine));
        pulseSequence.SetLoops(-1);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        TryToStopAnimation();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        PlaySequence();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        PlaySequence();
    }

    protected void PlaySequence()
    {
        pulseSequence.Play();
        rockSequence.Play();
    }

    protected void TryToStopAnimation()
    {
        if (rockSequence != null)
            rockSequence.Pause();

        if (pulseSequence != null)
            pulseSequence.Pause();
    }
}