using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogueSet;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialogueTitleText;
    private List<string> dialogueList;
    private int dialogueIndex;
    public PlayerMovement player;
    public void NewDialogue(string title,List<string> dialogues)
    {
        dialogueIndex = 0;
        dialogueTitleText.text = title;
        dialogueList = dialogues;
        dialogueText.text = dialogueList[dialogueIndex];
        dialogueSet.SetActive(true);
    }
    public void ContinueDialogue()
    {
        dialogueIndex += 1;
        if (dialogueIndex == dialogueList.Count) EndDialogue();
        else dialogueText.text = dialogueList[dialogueIndex];
    }
    public void EndDialogue() {
        dialogueSet.SetActive(false);
        player.ReceiveInput();
    }
}
