using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private VariationsCellsOperator levelLauncher;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private LevelCellData[] levelDatas;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject startLevelButton;
    [SerializeField] private GameObject choiceLevelButton;
    [SerializeField] private LevelVariations[] variations;
    [SerializeField] private PlayerStatusChecker playerStatusChecker;

    private LevelCellData _levelData;

    public PlayerStatusChecker PlayerStatusChecker => playerStatusChecker;
    public LevelCellData[] LevelDatas => levelDatas;

    private void Start()
    {
        if (PlayerPrefs.HasKey(Constants.NewGameStartedKey) == false)
        {
            PlayerPrefs.SetInt(Constants.NewGameStartedKey, 0);
            PlayerPrefs.SetInt(Constants.FirstLevelOpenedKey, 0);
        }

        foreach (LevelCellData levelData in levelDatas)
            levelData.Initialization(this);
    }

    public void GetInformationAboutActualLevel(LevelCellData levelData)
    {
        _levelData = levelData;
        choiceLevelButton.gameObject.SetActive(false);
        startLevelButton.gameObject.SetActive(true);

        if (PlayerPrefs.HasKey(Constants.ActualLevelKey))
            PlayerPrefs.DeleteKey(Constants.ActualLevelKey);

        PlayerPrefs.SetInt(Constants.ActualLevelKey, levelData.LevelNumber);
    }

    public void SelectNewButton()
    {
        soundManager.PlaySound(SoundType.Click);
        choiceLevelButton.gameObject.SetActive(true);
        startLevelButton.gameObject.SetActive(false);

        foreach (LevelCellData levelData in levelDatas)
            levelData.DisactivateGreenButtons();
    }

    public void ButtonPlayGame()
    {
        foreach (LevelVariations level in variations)
            level.gameObject.SetActive(false);

        if(_levelData != null)
        {
            for (int i = 0; i < _levelData.WindowsCount; i++)
                variations[i].gameObject.SetActive(true);
        }

        soundManager.PlaySound(SoundType.InGameMusic);
        menuManager.PlayGame();
        levelLauncher.Initialization(variations, _levelData);
    }
}
