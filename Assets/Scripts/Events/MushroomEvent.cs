using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEvent : DefaultEvent
{
    public GameObject canvasEffect;
    public override void EventOnStay(PlayerMovement player)
    {
        gameObject.SetActive(false);
        StartCoroutine(Tripping());
    }
    IEnumerator Tripping()
    {
        Debug.Log("hola");
        yield return null;
    }
}
