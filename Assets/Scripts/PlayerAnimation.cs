using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public float movingMargin = 0.1f;
    public float fallingMargin = 0.1f;

    private PlayerMovement pm;
    private Rigidbody2D rb;
    private Animator properties;
    private PlayerCombat combatController;
    private PlayerHealth playerHealth;

    void Start()
    {
        pm = transform.parent.GetComponent<PlayerMovement>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
        properties = GetComponent<Animator>();
        combatController = transform.parent.GetComponent<PlayerCombat>();
        playerHealth = transform.parent.GetComponent<PlayerHealth>();
    }

    
    void Update()
    {
        properties.SetBool("isMoving",Mathf.Abs(rb.velocity.x)>movingMargin);
        properties.SetBool("isFalling", pm.jumps < pm.initialJumps);
        properties.SetBool("isHit", playerHealth.isHit);
        properties.SetBool("isAttacking", combatController.attackHitBox.gameObject.activeSelf);
        properties.SetBool("isDead", playerHealth.health <= 0);
    }
}
