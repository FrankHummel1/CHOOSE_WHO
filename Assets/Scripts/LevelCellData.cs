using UnityEngine;

public class LevelCellData : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private int choicesCount;
    [SerializeField] private int windowsCount;
    [SerializeField] private AnimalSoundReproducer recorder;
    [SerializeField] private SOAnimalVariation[] animalsVariations;
    [Header("GameObjectsLevel")]
    [SerializeField] private GameObject locker;
    [SerializeField] private GameObject normalAllowLevel;
    [SerializeField] private GameObject greenAllowPlayLevel;
    [SerializeField] private GameObject oneStarLevelComplete;
    [SerializeField] private GameObject twoStarLevelComplete;
    [SerializeField] private GameObject threeStarLevelComplete;

    private GameManager _identificationLevelManager;
    private GameObject _actualButton;

    public int LevelNumber => levelNumber;
    public int ChoicesCount => choicesCount;
    public int WindowsCount => windowsCount;
    public SOAnimalVariation[] AnimalsVariations => animalsVariations;

    public void Initialization(GameManager levelManager)
    {
        CleanUpAllButtons();
        _identificationLevelManager = levelManager;

        if (PlayerPrefs.HasKey($"{Constants.LevelConditionKey}{levelNumber}"))
        {
            int levelConditionIndex = PlayerPrefs.GetInt($"{Constants.LevelConditionKey}{levelNumber}");

            levelManager.PlayerStatusChecker.PlusPointForStatus(levelConditionIndex);

            switch (levelConditionIndex)
            {
                case  0:
                    _actualButton = normalAllowLevel;
                    break;
                case 1:
                    _actualButton = oneStarLevelComplete;
                    break;
                case 2:
                    _actualButton = twoStarLevelComplete;
                    break;
                case 3:
                    _actualButton = threeStarLevelComplete;
                    break;
            }

            if(_actualButton != null)
                _actualButton.SetActive(true);
        }
        else locker.gameObject.SetActive(true);
    }

    private void CleanUpAllButtons()
    {
        locker.gameObject.SetActive(false);
        normalAllowLevel.gameObject.SetActive(false);
        oneStarLevelComplete.gameObject.SetActive(false);
        twoStarLevelComplete.gameObject.SetActive(false);
        threeStarLevelComplete.gameObject.SetActive(false);
        DisactivateGreenButtons();
    }

    public void DisactivateGreenButtons()
    {
        greenAllowPlayLevel.gameObject.SetActive(false);

        if (_actualButton != null)
            _actualButton.SetActive(true);
    }

    public void ButtonPressOnThisLevel()
    {
        _identificationLevelManager.SelectNewButton();
        greenAllowPlayLevel.gameObject.SetActive(true);
        _identificationLevelManager.GetInformationAboutActualLevel(this);
    }
}