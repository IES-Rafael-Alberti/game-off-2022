using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Ink.Runtime;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    public TextAsset dialogFile;

    private Story dialogs;

    private void Awake()
    {
        if(_instance == null )
            _instance = this;
        else
            Destroy(this);

        InitManager();
    }

    void InitManager()
    {
        dialogs = new Story(dialogFile.text);
    }

    public string GetDialog(string name)
    {
        string result = "";
        Container intro = dialogs.KnotContainerWithName(name);
        foreach (Ink.Runtime.Object line in intro.content)
            if(line.ToString() != "End") result += line.ToString();
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
