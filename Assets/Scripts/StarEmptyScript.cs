using UnityEngine;

public class StarEmptyScript : MonoBehaviour
{
    [SerializeField] private GameObject fullStar;
    [SerializeField] private GameObject emptyStar;

    private bool _isStarFull = true;

    public bool isStarFull => _isStarFull;

    public void EmptyThisStar()
    {
        fullStar.SetActive(false);
        emptyStar.SetActive(true);
        _isStarFull = false;
    }

    public void DefaultThisStars()
    {
        fullStar.SetActive(true);
        emptyStar.SetActive(false);
    }
}
