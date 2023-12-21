using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject wardrobeClose;
    [SerializeField] private GameObject wardrobeOpen;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("WardrobeUnlock", 1);
    }

    // Update is called once per frame
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
