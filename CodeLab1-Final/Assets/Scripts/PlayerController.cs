using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public bool hitStart = false;
    public int speed = 15;

    private Vector3 targetPos;
    public float mouseSpeed = 2.0f;

    public bool poweredUp = false;
    public bool doublePoints = false;

    PowerUpBase[] powers; //powerup array

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPos = transform.position;

        powers = GetComponents<PowerUpBase>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        if(hitStart == true)
        {
            
            Vector3 movement = new Vector3(0, 0, speed);
            rb.velocity = movement;

            float distance = transform.position.z - Camera.main.transform.position.z;
            targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

            targetPos = Camera.main.ScreenToWorldPoint(targetPos);
            Vector3 followXonly = new Vector3(targetPos.x, transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, followXonly, mouseSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Prize"))
        {
            if (doublePoints == false)
            {
                other.gameObject.SetActive(false);
                GameManager.instance.Score++; //increase the player's score using the Singleton
                Debug.Log("Score: " + GameManager.instance.Score); //print the score to console, using the Singleton
            }
            else if(doublePoints == true)
            {
                other.gameObject.SetActive(false);
                GameManager.instance.Score += 2; //increase the player's score x2 using the Singleton
                Debug.Log("Score: " + GameManager.instance.Score); //print the score to console, using the Singleton
            }


        }

        //GameObject player = gameObject;

        if (other.gameObject.CompareTag("PowerUp"))
        {
            if (poweredUp == false)
            {
                other.gameObject.SetActive(false);
                int randomPower = Random.Range(0, powers.Length);
                powers[randomPower].Upgrade(gameObject);
                poweredUp = true;
            }
        }


    }



    //public void LetsRoll()
    //{
    //    //rb.velocity = 
    //}

    public void StartGame()
    {
        Debug.Log("game started");
        hitStart = true;
    }
}
