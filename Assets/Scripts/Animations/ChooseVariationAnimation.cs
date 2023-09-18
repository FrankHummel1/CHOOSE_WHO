using UnityEngine.EventSystems;

public class ChooseVariationAnimation : ButtonAnimationMoving
{
    protected override void Start()
    {
        base.Start();
        TryToStopAnimation();
    }

    public override void OnPointerEnter(PointerEventData eventData) => PlaySequence();

    public override void OnPointerExit(PointerEventData eventData) => TryToStopAnimation();

    public override void OnPointerUp(PointerEventData eventData) { }
}
