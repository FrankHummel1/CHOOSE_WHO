using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundSwitcher[] soundSwitchers;
    [SerializeField] private AnimalSoundReproducer recorder;
    [SerializeField] private ButtonChangingColorPointing[] buttonsActive;
    [Header("Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource audioSource;
    [Header("Clips")]
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip inGameMusic;
    [SerializeField] private AudioClip clickOnImage;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip onPoint;
    [SerializeField] private AudioClip prohibited;
    [SerializeField] private AudioClip rightChoice;
    [SerializeField] private AudioClip wrongChoice;
    [SerializeField] private AudioClip looseSound;
    [SerializeField] private AudioClip winSound;
    [Header("StartVolumes")]
    [SerializeField] private float startVolumeMusic;
    [SerializeField] private float startVolumeSound;

    public AnimalSoundReproducer AnimalRecorder => recorder;

    private void Start()
    {
        musicSource.volume = startVolumeMusic;
        audioSource.volume = startVolumeSound;

        foreach (SoundSwitcher soundSwitcher in soundSwitchers)
        {
            switch(soundSwitcher.SoundSwitcherType)
            {
                case SoundSwitcherType.MusicSwitcher:
                        if (PlayerPrefs.HasKey("DisableMusic"))
                            soundSwitcher.DisableMusic();
                    break;
                case SoundSwitcherType.SoundSwitcher:
                    if (PlayerPrefs.HasKey("DisableSound"))
                        soundSwitcher.DisableSound();
                    break;
            }
        }


        PlaySound(SoundType.Music);

        foreach (ButtonChangingColorPointing button in buttonsActive)
            button.GetInformationAboutSoundManager(this);
    }

    public void PlaySound(SoundType sound)
    {
        switch (sound) 
        {
            case SoundType.Click:
                Playing(click);
                break;
            case SoundType.Point:
                Playing(onPoint);
                break;
            case SoundType.RightChoice:
                Playing(rightChoice);
                break;
            case SoundType.WrongChoice:
                Playing(wrongChoice);
                break;
            case SoundType.LooseSound:
                PlayMusic(looseSound);
                break;
            case SoundType.WinSound:
                PlayMusic(winSound);
                break;
            case SoundType.Prohibited:
                Playing(prohibited);
                break;
            case SoundType.InGameMusic:
                PlayMusic(inGameMusic);
                break;
            case SoundType.Music:
                PlayMusic(music);
                break;
        }
    }

    private void Playing(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void LockerSound() => PlaySound(SoundType.Prohibited);

    public void DisableSound() => audioSource.volume = 0;

    public void EnableSound() => audioSource.volume = startVolumeSound;

    public void PauseMusic() => musicSource.Pause();

    public void UnPauseMusic() => musicSource.UnPause();

    public void DisableMusic()
    {
        musicSource.volume = 0;
        musicSource.Pause();
    }

    public void EnableMusic()
    {
        musicSource.volume = startVolumeMusic;
        musicSource.UnPause();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
}