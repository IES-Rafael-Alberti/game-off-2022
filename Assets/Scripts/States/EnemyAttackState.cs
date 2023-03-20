using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyMainState
{
    Animator animator;
    public override void Enter(EnemyStateMachine playerStateMachine)
    {
        Debug.Log("Entering attack state");
        animator = playerStateMachine.owner.GetComponent<Animator>();
        playerStateMachine.attackHitBox.SetActive(false);
        animator.SetBool("isAttacking", true);
    }

    public override void Exit(EnemyStateMachine playerStateMachine)
    {

    }

    public override void OnCollisionEnter2D(EnemyStateMachine playerStateMachine, Collision2D collision)
    {

    }

    public override void Update(EnemyStateMachine playerStateMachine)
    {

    }
}
