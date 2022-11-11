using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
   
{
    public float health;
    public float gameOverMargin = 5f;

    public void RecieveDamage(float damage)
    {
        health -= damage;
        if (health <= 0) StartCoroutine(GameOver());
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(gameOverMargin);
        gameObject.SetActive(false);
    }
}
