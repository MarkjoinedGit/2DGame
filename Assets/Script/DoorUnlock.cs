using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] private GameObject doorClose;
    [SerializeField] private GameObject doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Door1Open", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Door1Open", 1) == 2)
        {
            doorClose.SetActive(false);
            doorOpen.SetActive(true);
            PlayerPrefs.SetInt("Door1Open", 1);
        }
    }
}
