using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class PrincessBehaviour : MonoBehaviour
{
    public float invulnerabilityTime = 2f;

    private bool isVulnerable = true;
    private CapsuleCollider2D capsuleCollider;
    private EnemyHealth enemyHealth;

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isVulnerable) {
            enemyHealth.RecieveDamage(1);
            StartCoroutine(SetVulnerable());
        }
    }

    IEnumerator SetVulnerable() {
        isVulnerable = false;
        yield return new WaitForSeconds(invulnerabilityTime);
        isVulnerable = true;
    }
}
