using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPotionEnter : DefaultEvent, ITextInfo
{

    public float healAmount = 1;


    public override void EventOnEnter(PlayerMovement player)
    {
        player.gameObject.GetComponent<PlayerHealth>().RecoverHealth(healAmount);
        gameObject.SetActive(false);
    }

    public string TextInfo()
    {
        return this.ToString();
    }

    public override string ToString()
    {
        return $"SPANISH DRY-CURED HAM: Heals {healAmount}";
    }
}
