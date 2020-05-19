using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.GetComponent<ASCIILevelLoader>().Go();
        GameManager.instance.RunManager();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
