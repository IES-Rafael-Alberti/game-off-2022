using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedState : EnemyMainState
{

    Animator animator;
    public override void Enter(EnemyStateMachine enemyStateMachine)
    {
        animator = enemyStateMachine.GetComponent<Animator>();
        enemyStateMachine.enemyHealth--;

        if (enemyStateMachine.enemyHealth == 0)
            animator.Play("EnemyDeath");
        else
        {
            animator.Play("EnemyHit");
            enemyStateMachine.GetComponentInChildren<SpriteRenderer>().material.color = Color.red;
        }
    }

    public override void Exit(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.GetComponentInChildren<SpriteRenderer>().material.color = Color.white;
    }

    public override void OnCollisionEnter2D(EnemyStateMachine enemyStateMachine, Collision2D collision)
    {

    }

    public override void Update(EnemyStateMachine enemyStateMachine)
    {
        
    }
}
