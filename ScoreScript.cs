using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    public AudioSource ding;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        score++;
        currentScoreText.text = score.ToString();
        ding.Play();
        UpdateHighScore();
    }
}
