using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEnter : DefaultEvent
{
    private DialogueEvent dialogue;
    private void Start()
    {
        dialogue = GetComponent<DialogueEvent>();
    }
    public override void EventOnEnter(PlayerMovement player) {
        player.StopInput();
        dialogue.StartDialogue();
        enabled = false;
    }
}
