using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    [SerializeField] private LayerMask m_WhatIsEnemy;
    private LogicManager m_logic;

    // Update is called once per frame
    void Start()
    {
        m_logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            m_logic.addScore(1);
        }
    }
}
