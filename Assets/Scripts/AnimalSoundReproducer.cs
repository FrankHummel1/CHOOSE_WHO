using System.Collections;
using UnityEngine;

public class AnimalSoundReproducer : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioSource recorderSound;
    [Header("ObjectsElements")]
    [SerializeField] private GameObject sounder;
    [SerializeField] private GameObject infoBegginer;
    [SerializeField] private GameObject lauchMusic;
    [SerializeField] private GameObject stopMusic;

    private IEnumerator _soundPlaying;
    private AudioClip _currentAnimalToChoice;
    private SOAnimalVariation _animalSo;

    public void IdentificationSound(SOAnimalVariation animalSo)
    {
        StopSound();
        _animalSo = animalSo;
        _currentAnimalToChoice = _animalSo.AnimalSound;
        recorderSound.clip = _currentAnimalToChoice;
    }

    public void PlaySound()
    {
        StopSound();
        TryStopCoroutine();
        _soundPlaying = PlaySoundCoroutine();
        StartCoroutine(_soundPlaying);
    }

    public IEnumerator PlaySoundCoroutine()
    {
        ObjectSwitcher(false, true, false, true);
        recorderSound.Play();
        soundManager.PauseMusic();
        yield return new WaitForSeconds(_currentAnimalToChoice.length);
        StopSound();
    }

    public void StopSound()
    {
        ObjectSwitcher(true, false, true, false);
        recorderSound.Stop();
        soundManager.UnPauseMusic();
    }

    private void OnDisable() => TryStopCoroutine();

    private void TryStopCoroutine()
    {
        if (_soundPlaying != null)
            StopCoroutine(_soundPlaying);
    }

    private void ObjectSwitcher(bool infoBegginerB, bool sounderB, bool lauchMusicB, bool stopMusicB)
    {
        infoBegginer.gameObject.SetActive(infoBegginerB);
        sounder.gameObject.SetActive(sounderB);
        lauchMusic.gameObject.SetActive(lauchMusicB);
        stopMusic.gameObject.SetActive(stopMusicB);
    }
}
