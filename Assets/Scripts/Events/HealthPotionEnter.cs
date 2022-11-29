using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionEnter : DefaultEvent
{

    public float healAmount = 1;

    public override void EventOnEnter(PlayerMovement player)
    {
        player.gameObject.GetComponent<PlayerHealth>().RecoverHealth(healAmount);
        gameObject.SetActive(false);
    }
}
