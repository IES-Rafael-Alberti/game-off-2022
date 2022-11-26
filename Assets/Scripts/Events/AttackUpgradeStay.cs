using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUpgradeStay : DefaultEvent
{

    public float damageIncrease = 1;

    public override void EventOnStay(PlayerMovement player)
    {
        player.gameObject.GetComponent<PlayerCombat>().attackHitBox.GetComponent<AttackHitbox>().damage += damageIncrease;
        gameObject.SetActive(false);
    }
}
