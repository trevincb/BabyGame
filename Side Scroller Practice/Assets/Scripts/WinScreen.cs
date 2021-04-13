using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI winText;
    bool isMyTimeDisplayed = false;
    
    void Start()
    {
        Time.timeScale = 0;
    }
    
    void Update()
    {
        if(isMyTimeDisplayed == false)
        {
            WinText();
            isMyTimeDisplayed = true;
        }
    }
    
    public void WinText()
    {
        gameObject.SetActive(true); //Setting the TextMeshProUGUI text field active
        winText.text = "MY TIME IS: " + Timer.instance.ReturnWinTime() + " SECONDS";
    }



    //Retry button - works fine after inspector is configured correctly
    public void RetryButton()
    {
        SceneManager.LoadScene("BabyGame");
    }

    //MainMenu button - works fine after inspector is configured correctly
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //NextLevel button - yet to work on - for now direct it to MainMenu
    public void NextLevelButton()
    {
        print("Go to Next Level - TBD");
        SceneManager.LoadScene("MainMenu");
    }
}
