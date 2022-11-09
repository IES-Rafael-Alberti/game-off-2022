using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public float movingMargin = 0.1f;
    public float fallingMargin = 0.1f;
    private Rigidbody2D rb;
    private Animator properties;
    private PlayerCombat combatController;
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        properties = GetComponent<Animator>();
        combatController = transform.parent.GetComponent<PlayerCombat>();
    }

    
    void Update()
    {
        properties.SetBool("isMoving",Mathf.Abs(rb.velocity.x)>movingMargin);
        properties.SetBool("isFalling", Mathf.Abs(rb.velocity.y) > fallingMargin);
        properties.SetBool("isAtacking", combatController.attackHitBox.gameObject.activeSelf);
    }
}
