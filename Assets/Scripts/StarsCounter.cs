using UnityEngine;

public class StarsCounter : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private StarEmptyScript[] stars;
    [SerializeField] private AnimalSoundReproducer recorder;

    private int _starIndex;

    public void MinusStar()
    {
        stars[_starIndex].EmptyThisStar();
        _starIndex++;

        if (_starIndex >= stars.Length)
        {
            recorder.StopSound();
            menuManager.LooseThisGame();
        }
    }

    public void DefaultAllStars()
    {
        _starIndex = 0;

        foreach (StarEmptyScript star in stars)
            star.DefaultThisStars();
    }

    public int CheckStars()
    {
        int starCount = 0;

        foreach (StarEmptyScript star in stars)
        {
            if (star.isStarFull)
                starCount++;
        }

        return starCount;
    }
}
