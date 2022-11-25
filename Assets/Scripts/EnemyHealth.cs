using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 3;
    public float gameOverMargin = 1f;
    public float hitAnimationSeconds = 0.5f;
    public bool isHit;

    public void RecieveDamage(float damage)
    {
        health -= damage;
        StartCoroutine(HitAnimation());
        if (health <= 0) StartCoroutine(DeathAnimation());
    }

    IEnumerator HitAnimation()
    {
        isHit = true;
        yield return new WaitForSeconds(hitAnimationSeconds);
        isHit = false;
    }

    IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(gameOverMargin);
        gameObject.SetActive(false);
    }
}
