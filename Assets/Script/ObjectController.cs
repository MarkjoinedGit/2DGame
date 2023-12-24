using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ObjectController : MonoBehaviour
{
    public bool m_openScene = false;
    [Header("EVents")]
    [Space]
    public UnityEvent OnHightLightEvent;
    public UnityEvent OffHightLightEvent;
    public UnityEvent OnAnotherSceneOpenEvent;

    // Start is called before the first frame update
    private void Awake()
    {
        if (OnHightLightEvent == null)
            OnHightLightEvent = new UnityEvent();
        if (OffHightLightEvent == null)
            OffHightLightEvent = new UnityEvent();
        if (OnAnotherSceneOpenEvent == null)
            OnAnotherSceneOpenEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Open"))
        {
            if (m_openScene)
            {
                OnAnotherSceneOpenEvent.Invoke();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnHightLightEvent.Invoke();
        m_openScene = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OffHightLightEvent.Invoke();
        m_openScene = false;
    }
}