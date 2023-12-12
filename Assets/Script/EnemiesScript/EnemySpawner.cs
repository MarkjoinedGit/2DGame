using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_SnailEnemyPrefab;
    [SerializeField] private GameObject m_FlyEnemyPrefab;
    [SerializeField] private float m_Interval = 1.5f;
    [SerializeField] private Text m_MaxScoreText;

    private int enemyMax;
    private int enemyCount = 0;
    private bool hasDecreasedAt50 = false;
    private bool hasDecreasedAt90 = false;
    private LogicManager m_logic;

    public int EnemyMax { get => enemyMax; set => enemyMax=value; }

    void Start()
    {
        m_logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        enemyMax = m_logic.enemyMax;
        string str = ("Target: " + enemyMax);
        m_MaxScoreText.text = str;
        StartCoroutine(spawnEnemy(m_Interval));
    }

    private IEnumerator spawnEnemy(float interval)
    {
        while (enemyCount < enemyMax && !m_logic.gameIsOver)
        {
            yield return new WaitForSeconds(interval);
            GameObject enemyToSpawn;
            int randomEnemy = Random.Range(0, 2); // Randomly choose 0 or 1
            if (randomEnemy == 0)
            {
                enemyToSpawn = m_SnailEnemyPrefab;
            }
            else
            {
                enemyToSpawn = m_FlyEnemyPrefab;
            }
            GameObject newEnemy = Instantiate(enemyToSpawn);
            enemyCount++;

            if (enemyCount >= enemyMax*0.9f && !hasDecreasedAt90)
            {
                interval *= 0.7f;
                hasDecreasedAt90 = true;
            }
            else if (enemyCount >= enemyMax*0.5f && !hasDecreasedAt50)
            {
                interval *= 0.7f;
                hasDecreasedAt50 = true;
            }
        }
    }
}
