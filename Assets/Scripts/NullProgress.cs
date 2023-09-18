using UnityEngine;

public class NullProgress : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private LevelCellData[] levelData;

    public void NullProgressMethod()
    {
        PlayerPrefs.DeleteKey("NewGameStarted");

        for(int i = 0; i < levelData.Length; i++)
        {
            if (PlayerPrefs.HasKey("LevelCondition" + i))
                PlayerPrefs.DeleteKey("LevelCondition" + i);
        }

        menuManager.RestartGame();
    }
}
