using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefaultEvent : MonoBehaviour, IEvent
{

    public virtual void EventOnStay(PlayerMovement player) {}

    public virtual void EventOnTrigger(PlayerMovement player) {}

}
