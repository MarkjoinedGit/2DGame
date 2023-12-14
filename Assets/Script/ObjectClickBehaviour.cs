using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickBehaviour : MonoBehaviour
{
    [SerializeField] private string requiredItem;
    private List<string> items;
    void Start()
    {
        items = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clickToExecute()
    {
        if (items.Contains(requiredItem))
            Debug.Log("Valid action");
        else
            Debug.Log("Invalid Aciont");
    }

    public void clickToCollect()
    {
        Debug.Log("click clothes");
        gameObject.SetActive(false);
    }
}
