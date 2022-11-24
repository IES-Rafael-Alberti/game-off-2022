using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public LoadManager loadManager;
    public string sceneName = "";
    public Vector3 newRespawn = Vector3.zero;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<DontDestroyOnLoad>().respawn = newRespawn;
            if (sceneName != "") loadManager.ChangeScene(SceneManager.GetSceneByName(sceneName).buildIndex);
            else loadManager.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
