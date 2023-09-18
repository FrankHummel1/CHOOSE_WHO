using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VariationsCellsOperator : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private TryCounter sliderCounter;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AnimalSoundReproducer animalRecorder;
    [SerializeField] private Button choiceButton;
    [SerializeField] private TMP_Text choiceButtonText;
    [SerializeField] private StarsCounter starsCounter;

    private LevelVariations[] _variations;
    private LevelCellData _levelData;
    private List<SOAnimalVariation> _variationsList = new List<SOAnimalVariation>();
    private List<int> _animalRepeatIndex = new List<int>();
    private int _randomNumber;
    private SOAnimalVariation _rightChoice;
    private SOAnimalVariation _playersChoice;

    public AnimalSoundReproducer AnimalRecorder => animalRecorder;
    public SoundManager SoundManager => soundManager;

    public void Initialization(LevelVariations[] variations, LevelCellData levelData)
    {
        _variations = variations;
        _levelData = levelData;
        sliderCounter.SetNumbersCount(_levelData, menuManager);
        CellsIdentification();
    }

    private void CellsIdentification()
    {
        if (sliderCounter.IsGameWined)
            return;

        _variationsList.Clear();

        for (int i = 0; i < _variations.Length; i++)
        {
            if (_variations[i].gameObject.active)
                FillerVariations(GetRandomIndexFromAnimal, i);
        }

        RandomizeChoice();
    }

    private void FillerVariations(int index, int levelVariationIndex)
    {
        _variations[levelVariationIndex].IdentificationVariation(_levelData.AnimalsVariations[index], this);
        _variationsList.Add(_levelData.AnimalsVariations[index]);
    }

    private int GetRandomIndexFromAnimal
    { 
        get
        {
            if(_animalRepeatIndex.Count >= _levelData.AnimalsVariations.Length)
                _animalRepeatIndex = new List<int>();

            int randomValue = 0;

            while (true)
            {
                randomValue = Random.Range(0, _levelData.AnimalsVariations.Length);

                if (!_animalRepeatIndex.Contains(randomValue))
                {
                    _randomNumber = randomValue;
                    _animalRepeatIndex.Add(randomValue);
                    break;
                }
            }   

            return _randomNumber;
        }
    }    
    
    private void RandomizeChoice()
    {
        int randomChoice = Random.Range(0, _levelData.WindowsCount);

        if(randomChoice <= _variationsList.Count)
        {
            animalRecorder.IdentificationSound(_variationsList[randomChoice]);
            _rightChoice = _variationsList[randomChoice];
        }
    }

    public void PlayerMadeChoice(SOAnimalVariation animalVariation)
    {
        _playersChoice = animalVariation;
        choiceButtonText.text = "ÂÛÁÐÀÒÜ: " + animalVariation.AnimalName;
        choiceButton.interactable= true;
    }

    public void ChoiceThisVariationButton()
    {
        if (_playersChoice.AnimalID == _rightChoice.AnimalID)
        {
            soundManager.PlaySound(SoundType.RightChoice);
            sliderCounter.DescreaseCount();
            CellsIdentification();
        }
        else
        {
            soundManager.PlaySound(SoundType.WrongChoice);
            starsCounter.MinusStar();
        }

        choiceButton.interactable = false;
        choiceButtonText.text = "ÂÛÁÐÀÒÜ!";
        ResetAllColorsVariations();
    }

    public void MakeAllNull()
    {
        _animalRepeatIndex.Clear();
        _animalRepeatIndex.Clear();
        _randomNumber = 0;
        _rightChoice = null;
        _playersChoice = null;
        sliderCounter.ResetWinStatus();
        soundManager.PlaySound(SoundType.Music);
    }

    public void ResetAllColorsVariations()
    {
        foreach(LevelVariations variation in _variations)
            variation.MakeAllVariationsStandart();
    }
}
