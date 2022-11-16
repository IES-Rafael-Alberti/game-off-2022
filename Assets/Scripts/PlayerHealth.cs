using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
   
{
    public float health;
    public float gameOverMargin = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered");
        if( collision.tag == "Death")
        {
            StartCoroutine(GameOver());
        }
    }
    public void RecieveDamage(float damage)
    {
        Debug.Log("Damage ="+ damage);
        health -= damage;
        if (health <= 0) StartCoroutine(GameOver());
    }
    IEnumerator GameOver()
    {
        Debug.Log("GameOver");
        yield return new WaitForSeconds(gameOverMargin);
        gameObject.SetActive(false);
    }
}
