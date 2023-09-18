using UnityEngine;
using UnityEngine.UI;

public class LevelVariations : MonoBehaviour
{
    [SerializeField] private Image imageVariation;
    [SerializeField] private Text animalName;
    [SerializeField] private Outline outLine;
    [SerializeField] private Color chosenColor;

    private VariationsCellsOperator _levelLauncher;
    private SOAnimalVariation _animalVariation;
    private Color _startColor;

    private void Start() => _startColor = outLine.effectColor;

    public void IdentificationVariation(SOAnimalVariation animal, VariationsCellsOperator levelLauncher)
    {
        imageVariation.sprite = animal.AnimalImage;
        animalName.text = animal.AnimalName;
        _levelLauncher = levelLauncher;
        _animalVariation = animal;
    }

    public void MakeChoice()
    {
        _levelLauncher.PlayerMadeChoice(_animalVariation);
        _levelLauncher.ResetAllColorsVariations();
        outLine.effectColor = chosenColor;
    }

    public void MakeAllVariationsStandart() => outLine.effectColor = _startColor;
}
