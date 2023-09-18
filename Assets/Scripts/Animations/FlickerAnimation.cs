using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlickerAnimation : MonoBehaviour
{
    [SerializeField] private float flickerSpeed;
    [SerializeField] private Image image;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;

    private bool _increasing = true;
    private Coroutine _flickerCoroutine;

    private void OnEnable() => _flickerCoroutine = StartCoroutine(FlickerCor());

    private void OnDisable()
    {
        if (_flickerCoroutine != null)
            StopCoroutine(_flickerCoroutine);
    }

    private IEnumerator FlickerCor()
    {
        float value = Constants.MinLerpValueForFlicker;

        while (true)
        {
            value += (_increasing ? 1 : -1) * flickerSpeed * Time.deltaTime;

            if (value < Constants.MinLerpValueForFlicker)
            {
                value = Constants.MinLerpValueForFlicker;
                _increasing = true;
            }
            else if (value > Constants.MaxLerpValueForFlicker)
            {
                value = Constants.MaxLerpValueForFlicker;
                _increasing = false;
            }

            Color lerpedColor = Color.Lerp(_startColor, _endColor, value);
            image.color = lerpedColor;

            yield return null;
        }
    }
}