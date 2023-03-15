using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Ink.Runtime;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextAsset dialogFile;
    public Texture2D DefaultCursor;
    public Texture2D DefaultInteractiveCursor;
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
        // Initialize game
        dialogs = new Story(dialogFile.text);
    }

    public string GetDialog(string name)
    {
        return string.Join("\n", GetDialogList(name));
    }

    public List<string> GetDialogList(string name)
    {
        List<string> result = new List<string>();
        if (name != null)
        {
            Container intro = dialogs.KnotContainerWithName(name);
            foreach (Ink.Runtime.Object line in intro.content)
                if (line.ToString() != "End" && line.ToString() != "\n") result.Add(line.ToString());
        } else
        {
            result.Add("error");
        }
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
