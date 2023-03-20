using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyMainState
{
    Animator animator;
    float stoppedCounter = 0;
    public override void Enter(EnemyStateMachine enemyStateMachine)
    {
        animator = enemyStateMachine.owner.GetComponent<Animator>(); 
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.SetBool(parameter.name, false);
        }
    }

    public override void Exit(EnemyStateMachine enemyStateMachine)
    {

    }

    public override void OnCollisionEnter2D(EnemyStateMachine enemyStateMachine, Collision2D collision)
    {
        enemyStateMachine.SwitchState(enemyStateMachine.attackState);
    }

    public override void Update(EnemyStateMachine enemyStateMachine)
    {
        stoppedCounter++;
        if(stoppedCounter >= 2000)
        {
            stoppedCounter = 0;
            enemyStateMachine.SwitchState(enemyStateMachine.patrolState);
        }
    }
}
