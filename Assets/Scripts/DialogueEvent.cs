using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{
    
    public DialogueController dialogueController;
    public List<string> dialogueList;
    public string title;

    public void StartDialogue()
    {
        dialogueController.NewDialogue(title, dialogueList);
    }
}
