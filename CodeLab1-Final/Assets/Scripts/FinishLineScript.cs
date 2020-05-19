using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineScript : MonoBehaviour
{
    public static int currentLevel = 0;
    public GameObject levelWonScreen;
    public GameObject levelLostScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().speed = 0;
            Debug.Log("Hit Finish");

            if (GameManager.instance.Score >= GameManager.instance.scoreToBeat)
            {
                levelWonScreen.gameObject.SetActive(true); //bring up the 'game won' screen
            }
            else
            {
                levelLostScreen.gameObject.SetActive(true); //bring up the 'game over' screen
            }

        }
    }

    public void Continue()
    {
        currentLevel++;
        SceneManager.LoadScene(currentLevel); //load next level
    }

    public void GoAgain()
    {
        GameManager.instance.Reset(); //restart game
        SceneManager.LoadScene(currentLevel);
    }
}
