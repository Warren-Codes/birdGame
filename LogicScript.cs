using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    [SerializeField]private GameObject gameOverCanvas;
    public AudioSource ding;
    public AudioSource flapSound;
    public AudioSource hitSound;
    public Text scoreText;
    public BirdScript birdScript;
    public static LogicScript instance;
    [ContextMenu("Increase Score")]

    public void addScore(int scoreToAdd) {
        if (birdScript.birdIsAlive) {
            //playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
           
        }
    }
    public void restartGame() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    public void gameOver() {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
   
}
