using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyMainState
{
    Animator animator;
    public override void Enter(EnemyStateMachine enemyStateMachine)
    {
        animator = enemyStateMachine.owner.GetComponent<Animator>();
        for(string boolName in animator.)
    }

    public override void Exit(EnemyStateMachine enemyStateMachine)
    {

    }

    public override void OnCollisionEnter2D(EnemyStateMachine enemyStateMachine)
    {

    }

    public override void Update(EnemyStateMachine enemyStateMachine)
    {

    }
}
