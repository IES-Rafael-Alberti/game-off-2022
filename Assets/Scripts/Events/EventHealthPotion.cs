using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHealthPotion : DefaultEvent
{

    public float damage = -1;

    public override void EventOnTrigger(PlayerMovement player)
    {
        Debug.Log("hola");
        player.gameObject.GetComponent<PlayerHealth>().RecieveDamage(damage);
        gameObject.SetActive(false);
    }
}
