using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSize : PowerUpBase
{
    public override void Upgrade(GameObject player)
    {
        Debug.Log("Growth PowerUp");
        player.GetComponent<SphereCollider>().radius = 5;
        
    }

}
