using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessTransformEnter : DefaultEvent
{
    public PrincessBehaviour princess;
    public override void EventOnEnter(PlayerMovement player)
    {
        if (!princess.isTransformed) StartCoroutine(TransformPrincess(player));
    }
    IEnumerator TransformPrincess(PlayerMovement player)
    {
        princess.isTransformed = true;
        player.StopInput();
        yield return new WaitForSeconds(princess.itsTransformingTime);
        princess.available = true;
        player.ReceiveInput();
        enabled = false;
    }
}
