using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ASCIILevelLoader : MonoBehaviour
{
 
    public GameObject prize;
    public GameObject powerUp;

    public float xOffset = -5;
    public float zOffset = -80;

    string fileLevel = "Level.txt";

    public int levelNum;


    // Start is called before the first frame update
    public void Go()
    {
        levelNum = SceneManager.GetActiveScene().buildIndex;

        switch (levelNum)
        {
            case 0:
                print("level0");
                fileLevel = "Level 0.txt";
                break;
            case 1:
                print("level1");
                fileLevel = "Level 1.txt";
                break;
            case 2:
                print("level2");
                fileLevel = "Level 2.txt";
                break;
            case 3:
                print("level3");
                fileLevel = "Level 3.txt";
                break;
            case 4:
                print("level4");
                fileLevel = "Level 4.txt";
                break;
            default:
                print("level not determined");
                fileLevel = "Level 0.txt";
                break;


        }


        string fullFilePath = Application.dataPath + "/Files/" + fileLevel;

        print("Full file path: " + fullFilePath);

        print(File.ReadAllText(fullFilePath));

       
        string[] lines = File.ReadAllLines(fullFilePath);

        
        GameObject prizeHolder = new GameObject("Prize Holder");

        //go through all the lines
        for (int z = 0; z < lines.Length; z++)
        {
            string line = lines[z]; //get each line

            char[] characters = line.ToCharArray();

            //go through each character on the current line
            for (int x = 0; x < characters.Length; x++)
            {
                GameObject newObject;

                switch (characters[x])
                {
                    case '*':
                        newObject = Instantiate<GameObject>(prize);
                        newObject.transform.SetParent(prizeHolder.transform); //make prize objects children of the holder
                        newObject.transform.position =
                                     new Vector3(x + xOffset, 1, z + zOffset);
                        break;
                    case 'p':
                        newObject = Instantiate<GameObject>(powerUp);
                        newObject.transform.position =
                                     new Vector3(x + xOffset, 1, z + zOffset);
                        break;
                    default:
                        print("empty");
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
