﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrizeScript : MonoBehaviour
{
    public static int currentLevel = 0;
    public int targetScore;

    // Start is called before the first frame update
    void Start()
    {
       // targetScore = GameManager.instance.Score * 2 + 0; //increase the target score every level
    }

    // Update is called once per frame
    void Update()
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

    }

    private void OnCollisionEnter(Collision collision) //If another GameObject with a 2D Collider on it hits this GameObject's collider
    {
        GameManager.instance.Score++; //increase the player's score using the Singleton!
        Debug.Log("Score: " + GameManager.instance.Score); //print the score to console, using the Singleton
      

        if (GameManager.instance.Score > targetScore) //if the current score >  the targetScore
        {
            //currentLevel++; //increate the level number
            //SceneManager.LoadScene(currentLevel); //go to the next level
        }
    }
}
