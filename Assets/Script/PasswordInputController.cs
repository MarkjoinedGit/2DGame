using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
    private Text m_Input;
    private string textFromInput;
    private string password;
    // Start is called before the first frame update
    void Awake()
    {
        m_Input = gameObject.GetComponent<Text>();
        textFromInput = "";
        password = "2812";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inputNumber(int number)
    {
        if (m_Input.text.Length < 4)
        {
            m_Input.text += "*";
            textFromInput += number.ToString();
            Debug.Log(textFromInput);
        }
    }

    public void delNumber()
    {
        if(m_Input.text.Length > 0)
        {
            m_Input.text = m_Input.text.Substring(0, m_Input.text.Length-1);
            textFromInput = textFromInput.Substring(0, textFromInput.Length-1);
            Debug.Log(textFromInput);
        }
    }

    public void checkPassword()
    {
        if (textFromInput.Equals(password))
        {
            Debug.Log("Correct password!!!");
            m_Input.text = "Correct!!!";
        }
    }
}
