using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpEnter : DefaultEvent
{
    public float popUpDuration;
    public TextPopUp popUp;
    public bool isDialoguePopUp = false;
    private void Start()
    {
        popUp = GetComponent<TextPopUp>();
    }
    public override void EventOnEnter(PlayerMovement player)
    {
        if (!popUp.enabled) StartCoroutine(PopMeUp());
    }
    private IEnumerator PopMeUp()
    {
        popUp.enabled = true;
        yield return new WaitForSeconds(popUpDuration);
        if (!isDialoguePopUp) popUp.enabled = false;
    }
}
