using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveRight;
    public KeyCode moveLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = Vector3.zero; // Initialize velocity as zero


        if (Input.GetKey(moveUp))
            velocity.y = 3;
        if (Input.GetKey(moveDown))
            velocity.y = -3;
        if (Input.GetKey(moveRight))
            velocity.x = 3;
        if (Input.GetKey(moveLeft))
            velocity.x = -3;

        // Set the Rigidbody2D velocity
        rb.velocity = velocity;
    }
}
