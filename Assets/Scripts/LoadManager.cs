using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public Animator loadScreen;
    public float minLoadingTime = 0.75f;
    public float newSceneTimer = 1f;
    public float loadingScreenTimer = 0.3f;
    public CameraFollow playerCamera;

    private GameObject player;
    private PlayerHealth playerHp;

    public void ChangeScene(int index)
    {
        StartCoroutine(LoadScene(index));
    }
    IEnumerator LoadScene(int index)
    {
        loadScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(minLoadingTime);
        AsyncOperation load = SceneManager.LoadSceneAsync(index);
        while (!load.isDone)
        {
            yield return null;
        }
        loadScreen.SetBool("Load", true);
        yield return new WaitForSeconds(newSceneTimer);
        player = playerCamera.gameObject;
        playerHp = player.GetComponent<PlayerHealth>();
        playerHp.health = playerHp.initialHealth; //TODO: Refactor in a function
        player.GetComponent<PlayerMovement>().ReceiveInput();
        playerCamera.gameObject.transform.position = playerCamera.gameObject.GetComponent<DontDestroyOnLoad>().respawn;
        playerCamera.SearchCamera();
        yield return new WaitForSeconds(loadingScreenTimer);
        loadScreen.gameObject.SetActive(false);
    }
}
