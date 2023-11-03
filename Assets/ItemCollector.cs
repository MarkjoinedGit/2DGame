using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;
    private Color highlightColor = Color.white;
    private Color originalColor;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        highlightColor = HexToColor("#FFF500");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //spriteRenderer.color = new Color(252f / 255f, 7f / 255f, 7f / 255f, 0.87f);
        Highlight();

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //spriteRenderer.color = Color.white;
        Unhighlight();
    }
    public void Highlight()
    {
        rend.material.color = highlightColor;
    }

    public void Unhighlight()
    {
        rend.material.color = originalColor;
    }
    Color HexToColor(string hex)
    {
        Color color = Color.black;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        return Color.black; // Trả về màu đen nếu chuyển đổi không thành công
    }
}
