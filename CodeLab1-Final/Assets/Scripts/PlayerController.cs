using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public bool hitStart = false;
    public int speed = 10;

    private Vector3 targetPos;
    public float mouseSpeed = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        if(hitStart == true)
        {
            Debug.Log("game started");
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
            other.gameObject.SetActive(false);
            GameManager.instance.Score++; //increase the player's score using the Singleton
            Debug.Log("Score: " + GameManager.instance.Score); //print the score to console, using the Singleton

        }
    }

    //public void LetsRoll()
    //{
    //    //rb.velocity = 
    //}

    public void StartGame()
    {
        hitStart = true;
    }
}
