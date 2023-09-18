using UnityEngine;

public class Nuller : MonoBehaviour
{
    [SerializeField] private TryCounter slider;
    [SerializeField] private StarsCounter starsCounter;
    [SerializeField] private VariationsCellsOperator levelLauncher;

    public void NullAll()
    {
        slider.MakeAllDefault();
        starsCounter.DefaultAllStars();
        levelLauncher.MakeAllNull();
    }
}
