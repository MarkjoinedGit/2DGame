using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickBehaviour : MonoBehaviour
{
    [SerializeField] private List<string> requiredItems;
    [SerializeField] private GameObject itemToCollect;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject objectToShow;
    private PlayerBag playerBag;

    void Start()
    {
        if (animator == null)
            animator = new Animator();
        playerBag = PlayerBag.Instance;
        if (itemToCollect == null)
            itemToCollect = new GameObject();
        if (objectToShow == null)
            objectToShow = new GameObject();
    }

    public void clickToExecute(float delay)
    {
        if (playerBag.removeItems(requiredItems) || requiredItems.Count == 0)
        {
            animator.SetBool("IsExecuted", true);
            if (gameObject.name == "Door")
                PlayerPrefs.SetInt("Door1Open", 2);
            Debug.Log("Valid action");
            StartCoroutine(ShowObjectAfterDelay(delay));
        }
        else
            Debug.Log("Invalid Aciont");
    }

    IEnumerator ShowObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        objectToShow.SetActive(true);
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
