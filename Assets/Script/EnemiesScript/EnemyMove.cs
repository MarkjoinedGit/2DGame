using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed = 3;
    [SerializeField] private float m_DeadZone = 0;

    private LogicManager m_logic;

    // Start is called before the first frame update
    void Start()
    {
        m_logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_logic.gameIsOver)
            transform.position = transform.position + (Vector3.left * m_MoveSpeed) * Time.deltaTime;

        if (transform.position.x < m_DeadZone)
            Destroy(gameObject);
    }
}
