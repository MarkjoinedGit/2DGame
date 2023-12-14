using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHighlight : MonoBehaviour
{
    public ObjectController controller;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHighlight()
    {
        animator.SetBool("IsHighLight", true);
       
    }


    public void OffHighlight()
    {
        animator.SetBool("IsHighLight", false);
    }
}
