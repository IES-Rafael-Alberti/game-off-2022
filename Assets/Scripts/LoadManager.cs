using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public Animator loadScreen;
    public float newSceneTimer = 1f;
    public CameraFollow playerCamera;

    public void ChangeScene(int index)
    {
        StartCoroutine(LoadScene(index));
    }
    IEnumerator LoadScene(int index)
    {
        loadScreen.gameObject.SetActive(true);
        AsyncOperation load = SceneManager.LoadSceneAsync(index);
        while (!load.isDone)
        {
            yield return null;
        }
        loadScreen.SetBool("Load", true);
        yield return new WaitForSeconds(newSceneTimer);
        playerCamera.SearchCamera();
        loadScreen.gameObject.SetActive(false);
    }
}
