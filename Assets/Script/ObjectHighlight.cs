using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHighlight : MonoBehaviour
{
    public ObjectController controller;
    public Animator animator;
    public float delaySecond = 1;
    public string nameScene = "main";
    public KeyCode selectKey = KeyCode.Space;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHighlight()
    {
        animator.SetBool("IsHighLight", true);
       
    }

    public void TurnAnotherScreen()
    {
        Debug.Log("Space");
        ModeSelect();
    }

    public void OffHighlight()
    {
        animator.SetBool("IsHighLight", false);
    }

    public void ModeSelect()
    {
        StartCoroutine(LoadAfterDelay());
    }
    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);
        SceneManager.LoadScene(nameScene);
    }
}
