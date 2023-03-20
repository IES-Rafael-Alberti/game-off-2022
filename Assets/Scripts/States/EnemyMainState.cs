
using UnityEngine;

public abstract class EnemyMainState
{
    public abstract void Enter(EnemyStateMachine enemyStateMachine);

    public abstract void Update(EnemyStateMachine enemyStateMachine);

    public abstract void Exit(EnemyStateMachine enemyStateMachine);

    public abstract void OnCollisionEnter2D(EnemyStateMachine enemyStateMachine, Collision2D collision);
}
