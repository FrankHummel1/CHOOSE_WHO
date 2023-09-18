using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IconLockerAnimation : MonoBehaviour
{
    [SerializeField] private float animationDuration;
    [SerializeField] private Vector3 initialScale = Vector3.one;
    [SerializeField] private Vector3 popScale = new Vector3();
    [SerializeField] private int numberOfBounces;
    [SerializeField] private Image iconImage;

    public void PlayIconAnimation()
    {
        iconImage.transform.localScale = initialScale;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(iconImage.transform.DOScale(popScale, animationDuration / Constants.SepparatenumberForLockerAnimation))
                .Append(iconImage.transform.DOScale(initialScale, animationDuration / Constants.SepparatenumberForLockerAnimation))
                .SetLoops(numberOfBounces);

        sequence.Play();
    }
}
