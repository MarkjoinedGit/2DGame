using UnityEngine;

public class PanelIntroGame : MonoBehaviour
{
    public KeyCode selectKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKey(selectKey))
        {
            gameObject.SetActive(false);
        }
    }
}
