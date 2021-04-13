using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // public GameOverScreen gameOverScreen;
    public static ScoreManager instance;
    public TextMeshProUGUI starScore;
    int score;
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int starValue)
    {
        score += starValue;
        starScore.text = "x " + score.ToString();
    }

    //public GetScore method so I can check score from other scripts
    public int GetScore()
    {
        return score;
    }
}
