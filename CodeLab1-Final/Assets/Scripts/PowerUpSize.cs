using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSize : PowerUpBase
{
    public override void Upgrade(GameObject player)
    {
        Debug.Log("Growth PowerUp");
        player.GetComponent<Transform>().localScale.Set(1.5f, 1.5f, 1.5f);
        
    }

}
