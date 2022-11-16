using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 3;
    public float gameOverMargin = 5f;

    public void RecieveDamage(float damage)
    {
        health -= damage;
        if (health <= 0) gameObject.SetActive(false);
    }
}