using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpEnter : DefaultEvent
{
    public float popUpDuration;
    public TextPopUp popUp;
    public string knot;
    public bool isDialoguePopUp = false;
    private void Start()
    {
        popUp = GetComponent<TextPopUp>();
    }
    public override void EventOnEnter(PlayerMovement player)
    {
        if (!popUp.enabled) StartCoroutine(PopMeUp());
    }
    public override void EventOnExit(PlayerMovement player)
    {
        if(isDialoguePopUp) popUp.enabled = false;
    }
    private IEnumerator PopMeUp()
    {
        if(!isDialoguePopUp)
            popUp.text = GameManager.Instance.GetDialog(knot);
        popUp.enabled = true;
        yield return new WaitForSeconds(popUpDuration);
        if (!isDialoguePopUp) popUp.enabled = false;
    }

}
