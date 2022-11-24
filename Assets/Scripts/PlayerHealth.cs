using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
   
{
    public float health;
    public float gameOverMargin = 5f;
    public float loadingScreenTime = 1f;
    public GameObject gameOverCanvas;
    public Animator loadScreen;

    private float initialHealth;
    private PlayerMovement playerMovement;

    private void Start()
    {
        initialHealth = health;
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Death")
        {
            health = 0;
            StartCoroutine(GameOver());
        }
    }
    public void RecieveDamage(float damage)
    {
        Debug.Log("Damage ="+ damage);
        health -= damage;
        if (health <= 0) {
            health = 0;
            StartCoroutine(GameOver());
        }
        if (health > initialHealth) health = initialHealth;
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(gameOverMargin);
        gameOverCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(loadingScreenTime);
        gameOverCanvas.gameObject.SetActive(false);
        loadScreen.gameObject.SetActive(true);
        AsyncOperation load = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        while (!load.isDone)
        {
            yield return null;
        }
        loadScreen.SetBool("Load", true);
        health = initialHealth;
        gameObject.SetActive(true);
        playerMovement.ReceiveInput();
        StartCoroutine(LoadNewScene());
    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(loadingScreenTime);
        playerMovement.GetComponent<CameraFollow>().SearchCamera();
        loadScreen.gameObject.SetActive(false);
    }
}
