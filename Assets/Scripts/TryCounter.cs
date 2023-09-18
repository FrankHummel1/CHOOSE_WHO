using UnityEngine;

public class TryCounter : MonoBehaviour
{
    [SerializeField] private GameObject[] sliderCounter;
    [SerializeField] private StarsCounter starCounter;
    [SerializeField] private GameManager levelIdentification;
    [SerializeField] private LevelWinningStarsChecker starsChecker;

    private LevelCellData _levelData;
    private bool _isGameWined;
    private int _indexCounter;
    private MenuManager _menuManager;

    public bool IsGameWined => _isGameWined;

    public void DescreaseCount()
    {
        sliderCounter[_indexCounter].SetActive(false);
        _indexCounter--;

        if (_indexCounter >= 0)
        {
            if (sliderCounter[_indexCounter] != null)
                sliderCounter[_indexCounter].SetActive(true);
        }
        else
        {
            _menuManager.WinThisGame();
            WinThisGame();
        }
    }

    public void SetNumbersCount(LevelCellData levelData, MenuManager menuManager)
    {
        _levelData = levelData;
        int indexCounter = levelData.ChoicesCount;
        indexCounter -= 1;
        _indexCounter = indexCounter;
        _menuManager = menuManager;
        MakeAllDefault();
        sliderCounter[indexCounter].SetActive(true);
    }

    public void MakeAllDefault()
    {
        foreach (GameObject count in sliderCounter)
            count.SetActive(false);
    }

    private void WinThisGame()
    {
        _isGameWined = true;

        if (PlayerPrefs.HasKey("LevelCondition" + _levelData.LevelNumber))
        {
            int starsCount = PlayerPrefs.GetInt("LevelCondition" + _levelData.LevelNumber);

            if (starsCount < starCounter.CheckStars())
            {
                PlayerPrefs.DeleteKey("LevelCondition" + _levelData.LevelNumber);
                PlayerPrefs.SetInt("LevelCondition" + _levelData.LevelNumber, starCounter.CheckStars());
            }
        }

        if (levelIdentification.LevelDatas.Length > _levelData.LevelNumber)
        {
            if (!PlayerPrefs.HasKey("LevelCondition" + (_levelData.LevelNumber + 1)))
                PlayerPrefs.SetInt("LevelCondition" + (_levelData.LevelNumber + 1), 0);
        }

        starsChecker.GetInformationAboutWinning(starCounter.CheckStars());
    }

    public void ResetWinStatus() => _isGameWined = false;
}
