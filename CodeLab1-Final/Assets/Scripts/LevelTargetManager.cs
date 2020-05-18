using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LevelTargetManager : MonoBehaviour
{
    //public Text targetScore =

    public int numLevels;

    public levelTarget currentLevel; //the current level

    public levelTarget[] levels; //array of all the levels

    string filePath = "/Files/Level<num>Target.json"; //default path to location files

    //once at the start
    void Start()
    {
        filePath = Application.dataPath + filePath; //full path to files

        levels = new levelTarget[numLevels]; //init array to have numLocation slots

        for (int i = 0; i < levels.Length; i++)
        { //0 to locations.Length
            string locPath = filePath.Replace("<num>", "" + i); //creating a path to file num "i"

            string fileContent = File.ReadAllText(locPath); //fileContent will hold all the text from the file at locPath

            levelTarget l = JsonUtility.FromJson<levelTarget>(fileContent);

            levels[i] = l;
        }

        UpdateLevel(0);
    }

    
    public void UpdateLevel(int locNum)
    {
        currentLevel = levels[locNum];

        string displayTargetText = GameManager.instance.displayScoreTemplate.Replace("<targetScore>", currentLevel.targetScore + "");

        //targetScore.text = currentLevel.targetScore;
        GameManager.instance.scoreText.text = displayTargetText;

        print("text from LevelTargetManager: " + GameManager.instance.scoreText.text);
        
    }
}
