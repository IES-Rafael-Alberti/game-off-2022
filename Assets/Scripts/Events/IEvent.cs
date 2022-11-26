using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEvent
{
    void EventOnEnter(PlayerMovement player);
    void EventOnStay(PlayerMovement player);
    void EventOnExit(PlayerMovement player);

}
