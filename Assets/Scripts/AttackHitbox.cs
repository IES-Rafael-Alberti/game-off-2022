using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public float damage = 1;
    private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;
    public bool hasHit = true;
    private void OnEnable()
    {
        hasHit = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.gameObject.tag);
        if (CompareTag("PlayerHitbox")) if (collision.gameObject.CompareTag("Enemy") && !collision.collider.gameObject.CompareTag("EnemyHitbox"))
            {
                enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
                if (hasHit) enemyHealth.RecieveDamage(damage);
                hasHit = false;
            }
        if (CompareTag("EnemyHitbox")) if (collision.gameObject.CompareTag("Player") && !collision.collider.gameObject.CompareTag("PlayerHitbox"))
            {
                playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (hasHit) playerHealth.RecieveDamage(damage);
                hasHit = false;
            }
    }
}
