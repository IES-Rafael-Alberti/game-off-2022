using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public float damage = 1;
    private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("PlayerHitbox")) if (collision.gameObject.CompareTag("Enemy")) { 
            enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.RecieveDamage(damage);
        }
        if (CompareTag("EnemyHitbox")) if (collision.gameObject.CompareTag("Player")) {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.RecieveDamage(damage);
        }
    }
}
