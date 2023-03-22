using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyMainState
{
    Animator animator;
    bool initialPos;
    Vector3 position;
    public override void Enter(EnemyStateMachine enemyStateMachine)
    {
        animator = enemyStateMachine.owner.GetComponent<Animator>();
        animator.SetBool("isMoving", true);
        position = enemyStateMachine.owner.transform.position;

        if (position == enemyStateMachine.startPosition.position)
            initialPos = true;
        else
            initialPos = false;
    }

    public override void Exit(EnemyStateMachine enemyStateMachine)
    {
        animator.SetBool("isMoving", false);
    }

    public override void OnCollisionEnter2D(EnemyStateMachine enemyStateMachine, Collision2D collision)
    {

    }

    public override void Update(EnemyStateMachine enemyStateMachine)
    {
        if (initialPos && position == enemyStateMachine.endPosition.position || !initialPos && position == enemyStateMachine.startPosition.position)
            enemyStateMachine.SwitchState(enemyStateMachine.idleState);

        if (initialPos)
        {
            enemyStateMachine.owner.transform.position = Vector2.MoveTowards(position, enemyStateMachine.endPosition.position, 5 * Time.deltaTime);
            enemyStateMachine.owner.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else
        {
            enemyStateMachine.owner.transform.position = Vector2.MoveTowards(position, enemyStateMachine.startPosition.position, 5 * Time.deltaTime);
            enemyStateMachine.owner.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }

        position = enemyStateMachine.owner.transform.position;
    }
}
