using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Nuller nuller;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject chooseLevelMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject looseScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject sureMenu;

    public void PlayGame()
    {
        chooseLevelMenu.SetActive(false);
        options.SetActive(false);
        menu.SetActive(false);
        gameUI.SetActive(true);
    }

    public void StartGame()
    {
        menu.gameObject.SetActive(false);
        chooseLevelMenu.gameObject.SetActive(true);
    }

    public void Options() => options.gameObject.SetActive(true);

    public void FromOptions() => options.gameObject.SetActive(false);

    public void FromStartGame()
    {
        menu.gameObject.SetActive(true);
        chooseLevelMenu.gameObject.SetActive(false);
    }

    public void RestartGame() => RestartScene();

    public void LooseThisGame()
    {
        gameUI.gameObject.SetActive(false);
        looseScreen.SetActive(true);
        soundManager.PlaySound(SoundType.LooseSound);
    }

    public void WinThisGame()
    {
        gameUI.gameObject.SetActive(false);
        winScreen.SetActive(true);
        soundManager.AnimalRecorder.StopSound();
        soundManager.PlaySound(SoundType.WinSound);
    }

    public void DisactivateGameUI() => gameUI.gameObject.SetActive(false);

    public void SureMenuEnter()
    {
        sureMenu.gameObject.SetActive(true);
        menu.gameObject.SetActive(false);
    }

    private void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void BackButtonFromWinScreen()
    {
        nuller.NullAll();
        RestartGame();
    }

    public void BackButtonFromLooseScreen()
    {
        nuller.NullAll();
        RestartGame();
    }

    public void BackButtonFromGameScreen()
    {
        nuller.NullAll();
        DisactivateGameUI();
        StartGame();
    }
}
