using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private Color highlightColor = Color.white;
    private Color originalColor;
    private Renderer rend;
    public float delaySecond = 1;
    public string nameScene = "main";
    public KeyCode selectKey = KeyCode.KeypadEnter;
    private bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        highlightColor = HexToColor("#FFF500");
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(selectKey))
        { 
           isSelected=true;
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player") )
        {
            
            Highlight();
            //collision.gameObject.SetActive(false);
            if(isSelected) 
            { 
                ModeSelect();
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Unhighlight();
    }
    private void Highlight()
    {
        rend.material.color = highlightColor;
    }

    private void Unhighlight()
    {
        rend.material.color = originalColor;
    }
    private Color HexToColor(string hex)
    {
        Color color = Color.black;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        return Color.black;
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
