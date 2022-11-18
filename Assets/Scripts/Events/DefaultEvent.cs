using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefaultEvent : MonoBehaviour, IEvent
{

    public void EventOnStay(PlayerMovement player) {}

    public void EventOnTrigger(PlayerMovement player) {}

}
