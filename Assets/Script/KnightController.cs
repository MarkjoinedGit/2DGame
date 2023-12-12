using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnightController : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 500f;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private LayerMask m_WhatIsEnemy;

    const float k_GroundedRadius = .2f;
    private bool m_Grounded;
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    private bool m_KnightIsAlive = true;
    private LogicManager m_logic;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    public bool KnightIsAlive { get => m_KnightIsAlive; set => m_KnightIsAlive=value; }

    private void Awake()
    {
        m_logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent==null)
            OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        if(m_KnightIsAlive)
        {
            bool wasGrounded = m_Grounded;
            m_Grounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, m_JumpForce/2500f, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded)
                    {
                        OnLandEvent.Invoke();
                    }
                }
            }
        }
        else
        {
            m_logic.gameOver();
        }
    }

    public void Move(float move, bool jump)
    {
        if (m_Grounded && jump)
        {
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((m_WhatIsEnemy.value & 1<<collision.gameObject.layer) == (1<<collision.gameObject.layer))
        {
            m_KnightIsAlive = false;
        }
    }
}
