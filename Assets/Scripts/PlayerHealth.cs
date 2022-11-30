using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
   
{
    public float health;
    public float gameOverAnimation = 1f;
    public float gameOverScreenTimer = 1f;
    public bool isHit = false;
    public GameObject gameOverCanvas;
    public LoadManager loadManager;
    public float initialHealth;
    public float hitAnimationSeconds = 1f; 
    
    private PlayerMovement playerMovement;

    private void Start()
    {
        initialHealth = health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Death")
        {
            if (health > 0)
            {
                health = 0;
                StartCoroutine(GameOver());
            }
        }
    }
    public void RecieveDamage(float damage)
    {
        if (health > 0){
            health -= damage;
            StartCoroutine(HitAnimation());
            if (health <= 0)
            {
                health = 0;
                StartCoroutine(GameOver());
            }
            if (health > initialHealth) health = initialHealth;
        }
    }

    public void RecoverHealth(float healAmount)
    {
        health += healAmount;
        if (health > initialHealth) health = initialHealth;
    }
    IEnumerator HitAnimation()
    {
        isHit = true;
        yield return new WaitForSeconds(hitAnimationSeconds);
        isHit = false;
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
