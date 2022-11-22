using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStay : DefaultEvent
{
    private DialogueEvent dialogue;
    private void Start()
    {
        dialogue = GetComponent<DialogueEvent>();
    }
    public override void EventOnStay(PlayerMovement player) {
        player.StopInput();
        dialogue.StartDialogue();
    }
}
