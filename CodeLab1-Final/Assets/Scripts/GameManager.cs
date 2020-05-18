using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance; //static var to hold Singleton

    public Text scoreText; //score text component
    public string displayScoreTemplate =
        "<currentScore>" +
        "/" +
        "<targetScore>";

    private const string FILE_HS_LIST = "/highscores.txt";

    public bool playing = true;

    private int score = 0;
    
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value; //set "score" to whatever value was passed
        }
    }

    public List<string> highScoreNames;
    public List<float> highScoreNums;


    private void Awake()
    {
        if (instance == null)
        { //instance hasn't been set yet
            instance = this; //set instance to this object
            DontDestroyOnLoad(gameObject); //Dont Destroy this object when you load a new scene
        }
        else
        { //if the instance is already set to an object
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //string displayScore = displayScoreTemplate.Replace("<targetScore>", LevelTargetManager.)

        highScoreNames = new List<string>();
        highScoreNums = new List<float>();

        if (File.Exists(Application.dataPath + FILE_HS_LIST))
        {
            string fileContents = File.ReadAllText(Application.dataPath + FILE_HS_LIST);
            string[] scorePairs = fileContents.Split('\n');



            for (int i = 0; i < 10; i++)
            {
                string[] nameScores = scorePairs[i].Split(' ');
                highScoreNames.Add(nameScores[0]);
                highScoreNums.Add(float.Parse(nameScores[1]));
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                highScoreNames.Add("SASH");
                highScoreNums.Add(10 + i * 10);
            }

        }

        Debug.Log(Application.dataPath);

        //scoreText = GetComponentInChildren<Text>(); //get the text component from the children of this gameObject
    }

    // Update is called once per frame
    void Update()
    {
        string displayScore = displayScoreTemplate.Replace("<currentScore>", Score + "");
        scoreText.text = displayScore;

    }

    public void UpdateHighScores()
    {
        bool newScore = false;

        for (int i = 0; i < highScoreNums.Count; i++)
        {
            if (highScoreNums[i] < Score)
            {
                highScoreNums.Insert(i, Score);
                highScoreNames.Insert(i, "NEW");
                newScore = true;
                break;

            }
        }

        if (newScore)
        {
            highScoreNums.RemoveAt(highScoreNums.Count - 1);
            highScoreNames.RemoveAt(highScoreNames.Count - 1);
        }

        string fileContents = "";

        for (int i = 0; i < highScoreNames.Count; i++)
        {
            fileContents += highScoreNames[i] + " " + highScoreNums[i] + "\n";
        }

        File.WriteAllText(Application.dataPath + FILE_HS_LIST, fileContents);
    }

    public void Reset()
    {
        score = 0;
        //PrizeScript.currentLevel = 0;
    }
}
