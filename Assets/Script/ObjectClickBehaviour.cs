using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickBehaviour : MonoBehaviour
{
    [SerializeField] private string requiredItem;
    [SerializeField] private GameObject itemToCollect;
    private PlayerBag playerBag;

    void Start()
    {
        playerBag = PlayerBag.Instance;
        if (itemToCollect == null)
            itemToCollect = new GameObject();
    }

    public void clickToExecute()
    {
        if (playerBag.removeItem(requiredItem))
            Debug.Log("Valid action");
        else
            Debug.Log("Invalid Aciont");
    }

    public void clickToCollect()
    {
        if (playerBag.addItem(gameObject))
        {
            gameObject.SetActive(false);
            //itemToCollect.SetActive(false);
        }    
    }
}
