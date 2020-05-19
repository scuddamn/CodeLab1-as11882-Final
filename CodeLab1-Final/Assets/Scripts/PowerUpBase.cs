using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{
    //base Power Up, gives a speed boost
    public virtual void Upgrade(GameObject player)
    {
        Debug.Log("Speed Boost PowerUp");
        player.GetComponent<PlayerController>().speed += 5;
    }
}
