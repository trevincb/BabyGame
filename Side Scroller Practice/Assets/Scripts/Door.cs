using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int winScore;
    public WinScreen winScreen;
    void FixedUpdate()
    {
        //Set open door animation when we collected all the stars
        if(ScoreManager.instance.GetScore() >= winScore)
            {
                GetComponent<Animator>().SetTrigger("Open");
            }
    }

    // // Door will flash when player collides with the door
    // // Only after all stars are collected
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.tag == "Player" && ScoreManager.instance.GetScore() >= winScore)
    //     {
    //         // GetComponent<Animator>().SetTrigger("Flash");
    //         // Timer.instance.Win();
    //     }
    // }
}
