﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    string highScoreTemplate =
        "Your Score: \n" +
        "<score> \n \n" +
        "High Score: \n" +
        "<highscores>";

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.UpdateHighScores();

        string displayText = highScoreTemplate.Replace("<score>", GameManager.instance.Score + "");

        string highScoreString = "";

        //temp vars
        List<string> hsNames = GameManager.instance.highScoreNames;
        List<float> hsNums = GameManager.instance.highScoreNums;

        for (int i = 0; i < hsNames.Count; i++)
        {
            highScoreString += hsNames[i] + "  " + hsNums[i] + "\n";
        }



        displayText = displayText.Replace("<highscores>", highScoreString);

        Debug.Log("displayText: " + displayText);

        highScoreText.text = displayText;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameManager.instance.Reset();
            SceneManager.LoadScene("Level1");
        }
    }
}