using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveRight;
    public KeyCode moveLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velocity = Vector3.zero;
        if (Input.GetKey(moveUp))
            velocity.y = 3;
        if (Input.GetKey(moveDown))
            velocity.y = -3;
        if (Input.GetKey(moveRight))
            velocity.x = 3;
        if (Input.GetKey(moveLeft))
            velocity.x = -3;
        rb.velocity = velocity;
    }
}
