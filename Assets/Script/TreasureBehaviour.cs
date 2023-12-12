using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBehaviour : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed = 3;
    [SerializeField] private Animator animator;

    private LogicManager m_logic;

    // Start is called before the first frame update
    void Start()
    {
        m_logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_logic.gameIsFinish && !m_logic.gameIsOver)
            transform.position = transform.position + (Vector3.left * m_MoveSpeed) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_MoveSpeed = 0;
        animator.SetBool("IsOpen", true);
        Invoke("RevealNumberAfterDelay", 0.25f);
    }

    private void RevealNumberAfterDelay()
    {
        m_logic.revealNumber();
    }
}
