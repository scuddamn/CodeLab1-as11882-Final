using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance; //static var to hold Singleton

    public Text scoreText; //score text component

    public string displayScoreTemplate =
        "<currentScore>" +
        "/" +
        "<targetScore>";

    private const string FILE_HS_LIST = "/Files/highscores.txt";

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

    #region LevelTargetManager

    public string targetScoreText;

    public int numLevels;

    public int scoreToBeat;

    public levelTarget currentLevel; //the current level

    public levelTarget[] levels; //array of all the levels

    string LTfilePath;// = "/Files/Level<num>Target.json"; //default path to location files
    #endregion

    string displayScore;

    public int levelNum;
    


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

        #region High Scores

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

        #endregion
    }

    public void RunManager()

    {
        levelNum = SceneManager.GetActiveScene().buildIndex;

        switch (levelNum)
        {
            case 0:
                print("level0");
                LTfilePath = "/Files/Level0Target.json";
                break;
            case 1:
                print("level1");
                LTfilePath = "/Files/Level1Target.json";
                break;
            case 2:
                print("level2");
                LTfilePath = "/Files/Level2Target.json";
                break;
            case 3:
                print("level3");
                LTfilePath = "/Files/Level3Target.json";
                break;
            case 4:
                print("level4");
                LTfilePath = "/Files/Level4Target.json";
                break;
            default:
                print("level not determined");
                LTfilePath = "/Files/Level0Target.json";
                break;


        }
        

        string locPath = Application.dataPath + LTfilePath; //full path to files

        #region LevelTargetManager

        levels = new levelTarget[numLevels]; //init array to have numLevels slots

        for (int i = 0; i < levels.Length; i++)
        { 
            //string locPath = LTfilePath.Replace("<num>", "" + i); //creating a path to file num "i"

            string fileContent = File.ReadAllText(locPath); //fileContent will hold all the text from the file at locPath

            levelTarget l = JsonUtility.FromJson<levelTarget>(fileContent);

            levels[i] = l;
        }

        UpdateLevel(0);

        #endregion

        //scoreText = GetComponentInChildren<Text>(); //get the text component from the children of this gameObject
    }

    // Update is called once per frame
    void Update()
    {
        displayScore = displayScoreTemplate.Replace("<currentScore>", Score + "").Replace("<targetScore>", targetScoreText);
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

    public void UpdateLevel(int locNum)
    {
        currentLevel = levels[locNum];
        targetScoreText = currentLevel.targetScore;
        scoreToBeat = currentLevel.scoreToBeat;

        Debug.Log("Level Updated");

    }

    public void Reset()
    {
        score = 0;
        FinishLineScript.currentLevel = 0;
    }
}
