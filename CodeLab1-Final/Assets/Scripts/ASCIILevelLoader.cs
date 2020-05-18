using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
 
    public GameObject prize;

    public float xOffset = -5;
    public float zOffset = -80;

    public string fileLevel = "Level.txt";

    // Start is called before the first frame update
    void Start()
    {
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
