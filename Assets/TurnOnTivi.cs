using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTivi : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        animator.SetBool("turn-on", true);
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("turn-on", false);
    }
}
