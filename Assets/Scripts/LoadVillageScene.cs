using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadVillageScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
        SceneManager.LoadScene("0.5-Intro");
    }


    public void CloseScrollButton()
    {
        SceneManager.LoadScene("1-Village");
    }

    public void CloseScrolltoTitleButton()
    {
        SceneManager.LoadScene("0-Title");
    }
}
