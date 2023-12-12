using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public bool gameIsOver = false;
    public bool gameIsFinish = false;
    public int enemyMax = 50;
    public GameObject gameOverScreen;
    public GameObject gameWinningScreen;

    private void Update()
    {
        if (Convert.ToInt16(scoreText.text) == enemyMax)
            gameIsFinish = true;
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameIsOver = true;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void revealNumber()
    {
        gameWinningScreen.SetActive(true);
    }

    public void backToMainGame()
    {
        Debug.Log("Space");
        ModeSelect();
    }

    public void ModeSelect()
    {
        StartCoroutine(LoadAfterDelay());
    }
    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("main");
    }
}