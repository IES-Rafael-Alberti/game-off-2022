using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{

    private List<string> dialogueList;
    public string title;
    public string knot;

    private DialogueController dialogueController;

    private void Start()
    {
        // better find...bytype
        //dialogueController = GameObject.Find("Dialogue Controller").GetComponent<DialogueController>();
        dialogueController = FindFirstObjectByType<DialogueController>();
    }

    public void StartDialogue()
    {
        dialogueController.NewDialogue(title, GameManager.Instance.GetDialogList(knot));
    }
}
