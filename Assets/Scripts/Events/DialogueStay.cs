using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStay : DefaultEvent
{
    private DialogueEvent dialogue;
    private PopUpEnter popUpComponent;
    private void Start()
    {
        dialogue = GetComponent<DialogueEvent>();
        popUpComponent = GetComponent<PopUpEnter>();
    }
    public override void EventOnStay(PlayerMovement player) {
        player.StopInput();
        if (popUpComponent) popUpComponent.popUp.enabled = false;
        dialogue.StartDialogue();
    }
}
