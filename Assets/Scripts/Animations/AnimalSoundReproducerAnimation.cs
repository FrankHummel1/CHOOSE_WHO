using DG.Tweening;
using UnityEngine;

public class AnimalSoundReproducerAnimation : MonoBehaviour
{
    [SerializeField] private float rotationAmount;
    [SerializeField] private float pulseDuration;

    private Vector3 _startRotation;
    private Sequence _pulseSequence;

    private void Start()
    {
        _startRotation = transform.eulerAngles;

        if (gameObject.activeSelf)
        {
            CreatePulseAnimation();
            StartPulseAnimation();
        }
    }

    private void OnEnable()
    {
        if (isActiveAndEnabled)
        {
            CreatePulseAnimation();
            StartPulseAnimation();
        }
    }

    private void OnDisable()
    {
        StopPulseAnimation();
        ResetObjectRotation();
    }

    private void CreatePulseAnimation()
    {
        _pulseSequence = DOTween.Sequence();
        _pulseSequence.Append(transform.DORotate(_startRotation + new Vector3(0f, 0f, rotationAmount), pulseDuration / 2f));
        _pulseSequence.Append(transform.DORotate(_startRotation, pulseDuration / 2f));
        _pulseSequence.SetLoops(-1);
    }

    private void StartPulseAnimation() => _pulseSequence.Play();

    private void StopPulseAnimation() => _pulseSequence.Kill();

    private void ResetObjectRotation() => transform.eulerAngles = _startRotation;
}
