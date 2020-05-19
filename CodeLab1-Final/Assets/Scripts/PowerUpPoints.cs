using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPoints : PowerUpBase
{
    public override void Upgrade(GameObject player)
    {
        Debug.Log("Double Points PowerUp");
        player.GetComponent<PlayerController>().doublePoints = true;
    }
}
