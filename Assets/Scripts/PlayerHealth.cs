using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
   
{
    public float health;
    public float gameOverAnimation = 1f;
    public float gameOverScreenTimer = 1f;
    public GameObject gameOverCanvas;
    public LoadManager loadManager;
    public float initialHealth;
    

    private void Start()
    {
        initialHealth = health;
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
        if (health > 0){
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                StartCoroutine(GameOver());
            }
            if (health > initialHealth) health = initialHealth;
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(gameOverAnimation);
        gameOverCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(gameOverScreenTimer);
        gameOverCanvas.gameObject.SetActive(false);
        loadManager.ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }
}
