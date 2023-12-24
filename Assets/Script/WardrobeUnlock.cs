using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject wardrobeClose;
    [SerializeField] private GameObject wardrobeOpen;
    void Start()
    {
        PlayerPrefs.SetInt("WardrobeUnlock", 1);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("WardrobeUnlock", 1) == 2)
        {
            wardrobeClose.SetActive(false);
            wardrobeOpen.SetActive(true);
            PlayerPrefs.SetInt("WardrobeUnlock", 1);
        }
    }
}
