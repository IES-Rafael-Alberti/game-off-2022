using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{

    public List<string> dialogueList;
    public string title;

    private DialogueController dialogueController;

    private void Start()
    {
        dialogueController = GameObject.Find("Dialogue Controller").GetComponent<DialogueController>();
    }

    public void StartDialogue()
    {
        dialogueController.NewDialogue(title, dialogueList);
    }
}
