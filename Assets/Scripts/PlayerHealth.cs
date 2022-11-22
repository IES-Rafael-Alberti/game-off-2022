using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
   
{
    public float health;
    public float gameOverMargin = 5f;

    private float initialHealth;
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
        Debug.Log("GameOver");
        yield return new WaitForSeconds(gameOverMargin);
        gameObject.SetActive(false);
    }
}
