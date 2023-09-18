using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "AnimalVariation/Animal")]

public class SOAnimalVariation : ScriptableObject
{
    [SerializeField] private int animalID;
    [SerializeField] private string animalName;
    [SerializeField] private Sprite animalImage;
    [SerializeField] private AudioClip animalSound;

    public int AnimalID => animalID;
    public string AnimalName => animalName;
    public Sprite AnimalImage => animalImage;
    public AudioClip AnimalSound => animalSound;
}
