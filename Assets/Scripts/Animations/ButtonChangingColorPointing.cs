using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonChangingColorPointing : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    [SerializeField] protected Button button;
    [SerializeField] protected Color endColor;
    [SerializeField] protected Image image;

    protected SoundManager soundManager;
    protected Color startColor;

    protected virtual void Start()
    {
        startColor = image.color;
        button.onClick.AddListener(OnButtonClick);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        soundManager.PlaySound(SoundType.Point);
        image.color = endColor;
    }

    public virtual void OnButtonClick() => soundManager.PlaySound(SoundType.Click);

    public virtual void OnPointerExit(PointerEventData eventData) => image.color = startColor;

    public virtual void OnPointerUp(PointerEventData eventData) => image.color = startColor;

    public void GetInformationAboutSoundManager(SoundManager soundManager) => this.soundManager = soundManager;

    private void OnDestroy() => button.onClick.RemoveListener(OnButtonClick);
}
