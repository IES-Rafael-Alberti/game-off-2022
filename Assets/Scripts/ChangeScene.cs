using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName = "";
    public Vector3 newRespawn = Vector3.zero;
    public bool canEnter = true;

    private LoadManager loadManager;

    private void Start()
    {
        loadManager = GameObject.Find("Load Manager").GetComponent<LoadManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canEnter) {
            collision.gameObject.GetComponent<DontDestroyOnLoad>().respawn = newRespawn;
            if (sceneName != "") loadManager.ChangeScene(SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/" + sceneName + ".unity"));           
            else loadManager.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
