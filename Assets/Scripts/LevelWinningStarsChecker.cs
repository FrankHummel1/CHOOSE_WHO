using UnityEngine;

public class LevelWinningStarsChecker : MonoBehaviour
{
    [SerializeField] private GameObject[] starsObjects;

    public void GetInformationAboutWinning(int starIndex)
    { 
        starIndex -= 1;
        starsObjects[starIndex].SetActive(true);
    }
}
