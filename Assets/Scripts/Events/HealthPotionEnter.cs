using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionEnter : DefaultEvent, ITextInfo
{

    public float healAmount = 1;

    public override void EventOnEnter(PlayerMovement player)
    {
        player.gameObject.GetComponent<PlayerHealth>().RecoverHealth(healAmount);
        gameObject.SetActive(false);
    }

    public void Show()
    {
        Debug.Log(this);
    }

    public override string ToString()
    {
        return $"Cura {healAmount} vidas.";
    }
}
