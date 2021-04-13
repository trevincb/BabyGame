using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    Image timerBar;
    public float maxTime;
    float timeLeft;
    public static float winTime;
    public GameOverScreen gameOverScreen;
    public static Timer instance;
    public TextMeshProUGUI timerBarText;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;      
    }

    void Update()
    {
        if(timeLeft > 0 && Time.timeScale == 1)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            winTime = maxTime - timeLeft;
            DisplayTimerBarText();
        }
        else if(timeLeft <= 0)
        {
            gameOverScreen.ScoreText(ScoreManager.instance.GetScore());
            Time.timeScale = 0;
        }
    }

    public float ReturnWinTime()
    {
        winTime = Mathf.Round(winTime * 100f) / 100f;
        return winTime;
    }

    public void DisplayTimerBarText()
    {
        timerBarText.text = "Time Left: " + Mathf.Round(timeLeft);
    }
}
