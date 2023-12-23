using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInputerController : MonoBehaviour
{
    public List<Text> m_Input;
    private string textFromInput;
    private string password = "1104";
    [SerializeField] private GameObject doorClose;
    [SerializeField] private GameObject doorOpen;
    //public GameObject numberInput;
    private int colorIndex = 0;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void inputNumber(int number)
    {
        if (colorIndex < m_Input.Count && m_Input[colorIndex].text.Length < 4)
        {
            m_Input[colorIndex].text += number.ToString();
            textFromInput += number.ToString();
            colorIndex++;
            Debug.Log(textFromInput);
        }
    }

    public void delNumber()
    {
        if(colorIndex > 0)
        {
            m_Input[colorIndex-1].text = "";
            textFromInput = textFromInput.Substring(0, textFromInput.Length - 1);
            colorIndex--;
            Debug.Log(textFromInput);
        }   
    }

    public void checkPassword()
    {
        if (textFromInput.Equals(password))
        {
            Debug.Log("Correct password!!!");
            doorClose.SetActive(false);
            doorOpen.SetActive(true);
            PlayerPrefs.SetInt("DoorMainOpen", 2);
        }
    }

}
