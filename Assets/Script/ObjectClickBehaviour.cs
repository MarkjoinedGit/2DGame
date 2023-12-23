using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickBehaviour : MonoBehaviour
{
    [SerializeField] private List<string> requiredItems;
    [SerializeField] private GameObject itemToCollect;
    [SerializeField] private Animator animator;
    private PlayerBag playerBag;

    void Start()
    {
        if (animator == null)
            animator = new Animator();
        playerBag = PlayerBag.Instance;
        if (itemToCollect == null)
            itemToCollect = new GameObject();
    }

    public void clickToExecute()
    {
        if (playerBag.removeItems(requiredItems))
        {
            animator.SetBool("IsExecuted", true);
            if (gameObject.name == "Door")
                PlayerPrefs.SetInt("Door1Open", 2);
            Debug.Log("Valid action");
        }
        else
            Debug.Log("Invalid Aciont");
    }

    public void clickToCollect()
    {
        if (playerBag.addItem(gameObject))
        {
            gameObject.SetActive(false);
            itemToCollect.SetActive(false);
        }    
    }
}
