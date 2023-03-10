using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] string dialogName;

    // Start is called before the first frame update
    void Start()
    {
        string text = FindAnyObjectByType<GameManager>().GetDialog(dialogName);
        GetComponent<TextMeshProUGUI>().text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
