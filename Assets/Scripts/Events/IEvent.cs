using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEvent
{
    void EventOnTrigger(PlayerMovement player);
    void EventOnStay(PlayerMovement player);

}
