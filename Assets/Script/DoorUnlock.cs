using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] private GameObject doorClose;
    [SerializeField] private GameObject doorOpen;
    [SerializeField] private GameObject unsceneMainDoor;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Door1Open", 1);
        PlayerPrefs.SetInt("DoorMainOpen", 1);
        if (unsceneMainDoor == null)
            unsceneMainDoor = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Door1Open", 1) == 2 && gameObject.name == "DoorClose")
        {
            doorClose.SetActive(false);
            doorOpen.SetActive(true);
            PlayerPrefs.SetInt("Door1Open", 1);
        }

        if (PlayerPrefs.GetInt("DoorMainOpen", 1) == 2 && gameObject.name == "MainDoorClose")
        {
            doorClose.SetActive(false);
            doorOpen.SetActive(true);
            PlayerPrefs.SetInt("DoorMainOpen", 1);
            gameIsWin();
        }
    }

    public void gameIsWin()
    {
        unsceneMainDoor.SetActive(false);
        Debug.Log("Game is win!!!");
    }
}
