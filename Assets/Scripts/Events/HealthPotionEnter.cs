using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionEnter : DefaultEvent
{

    public float damage = -1;

    public override void EventOnEnter(PlayerMovement player)
    {
        player.gameObject.GetComponent<PlayerHealth>().RecieveDamage(damage);
        gameObject.SetActive(false);
    }
}
