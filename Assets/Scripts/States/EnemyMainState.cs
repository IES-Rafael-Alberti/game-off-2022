
using UnityEngine;

public abstract class EnemyMainState
{
    public abstract void Enter(EnemyStateMachine playerStateMachine);

    public abstract void Update(EnemyStateMachine playerStateMachine);

    public abstract void Exit(EnemyStateMachine playerStateMachine);

    public abstract void OnCollisionEnter2D(EnemyStateMachine playerStateMachine);
}
