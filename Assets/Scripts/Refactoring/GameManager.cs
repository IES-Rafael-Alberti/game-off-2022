using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Ink.Runtime;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextAsset dialogFile;

    private Story dialogs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitManager();
        }
        else
            Destroy(this);
    }

    void InitManager()
    {
        Debug.Log("Inicializando gamemanager");

        // Initialize game
        dialogs = new Story(dialogFile.text);
    }

    public string GetDialog(string name)
    {
        return string.Join("", GetDialogList(name));
    }

    public List<string> GetDialogList(string name)
    {
        List<string> result = new List<string>();
        Container intro = dialogs.KnotContainerWithName(name);
        foreach (Ink.Runtime.Object line in intro.content)
            if (line.ToString() != "End") result.Add(line.ToString());
        return result;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
