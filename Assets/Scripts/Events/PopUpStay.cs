using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpStay : DefaultEvent
{
    public float popUpDuration;
    private TextPopUp popUp;
    private void Start()
    {
        popUp = GetComponent<TextPopUp>();
    }
    public override void EventOnStay(PlayerMovement player)
    {
        if (!popUp.enabled) StartCoroutine(PopMeUp());
    }
    private IEnumerator PopMeUp()
    {
        popUp.enabled = true;
        yield return new WaitForSeconds(popUpDuration);
        popUp.enabled = false;
    }
}
