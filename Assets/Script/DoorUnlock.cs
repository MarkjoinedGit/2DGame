using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] private GameObject doorClose;
    [SerializeField] private GameObject doorOpen;
    [SerializeField] private GameObject unsceneMainDoor;
    private Player player;

    void Start()
    {
        player =Player.Instance;
        PlayerPrefs.SetInt("Door1Open", 1);
        PlayerPrefs.SetInt("DoorMainOpen", 1);
        if (unsceneMainDoor == null)
            unsceneMainDoor = new GameObject();
    }

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
        player.ScenesAreFinished.Add("main");
        Debug.Log("Game is win!!!");
    }
}
