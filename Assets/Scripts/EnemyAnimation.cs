using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public float movingMargin = 0.1f;
    private Rigidbody2D rb;
    private Animator properties;
    private EnemyBehavior combatController;
    private EnemyHealth enemyHealth;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        properties = GetComponent<Animator>();
        combatController = transform.parent.GetComponent<EnemyBehavior>();
        enemyHealth = transform.parent.GetComponent<EnemyHealth>();
    }


    void Update()
    {
        properties.SetBool("isMoving", Mathf.Abs(rb.velocity.x) > movingMargin);
        properties.SetBool("isHit", enemyHealth.isHit);
        properties.SetBool("isAttacking", combatController.attackHitBox.gameObject.activeSelf);
        properties.SetBool("isDead", enemyHealth.health <= 0);
    }
}
