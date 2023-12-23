using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SafeDepositController : MonoBehaviour
{
    public GameObject OpenSafeScene;
    public void openSafe()
    {
        OpenSafeScene.SetActive(true);
        gameObject.SetActive(false);
    }
}
