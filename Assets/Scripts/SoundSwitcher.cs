using UnityEngine;

public class SoundSwitcher : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject turnOffButtom;
    [SerializeField] private GameObject turnOnButtom;
    [SerializeField] private SoundSwitcherType soundSwitcherType;

    public SoundSwitcherType SoundSwitcherType => soundSwitcherType;

    public void EnableMusic()
    {
        if (PlayerPrefs.HasKey(Constants.DisableMusicKey))
            PlayerPrefs.DeleteKey(Constants.DisableMusicKey);

        turnOnButtom.gameObject.SetActive(true);
        turnOffButtom.gameObject.SetActive(false);
        soundManager.EnableMusic();
    }

    public void DisableMusic()
    {
        if (!PlayerPrefs.HasKey(Constants.DisableMusicKey))
            PlayerPrefs.SetInt(Constants.DisableMusicKey, 1);

        turnOffButtom.gameObject.SetActive(true);
        turnOnButtom.gameObject.SetActive(false);
        soundManager.DisableMusic();
    }

    public void EnableSound()
    {
        if (PlayerPrefs.HasKey(Constants.DisableSoundKey))
            PlayerPrefs.DeleteKey(Constants.DisableSoundKey);

        turnOnButtom.gameObject.SetActive(true);
        turnOffButtom.gameObject.SetActive(false);
        soundManager.EnableSound();
    }

    public void DisableSound()
    {
        if (!PlayerPrefs.HasKey(Constants.DisableSoundKey))
            PlayerPrefs.SetInt(Constants.DisableSoundKey, 1);

        turnOffButtom.gameObject.SetActive(true);
        turnOnButtom.gameObject.SetActive(false);
        soundManager.DisableSound();
    }
}
