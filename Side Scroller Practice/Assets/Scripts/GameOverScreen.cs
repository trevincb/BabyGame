using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeLastedText;
    

    public void ScoreText(int score)
    {
        gameObject.SetActive(true); //Setting the TextMeshProUGUI text field active
        scoreText.text = "COLLECTED " + score + " / 10 STARS";
        timeLastedText.text = "in " + Timer.instance.ReturnWinTime() + " seconds";
    }

    //Retry button - works fine after inspector is configured correctly
    public void RetryButton()
    {
        SceneManager.LoadScene("BabyGame"); // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //MainMenu button - works fine after inspector is configured correctly
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
