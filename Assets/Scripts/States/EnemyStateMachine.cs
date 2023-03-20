using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public GameObject owner;
    public GameObject attackHitBox;
    public Transform startPosition;
    public Transform endPosition;

    EnemyMainState currentState;
    public EnemyMainState idleState = new EnemyIdleState();
    public EnemyMainState attackState = new EnemyAttackState();
    public EnemyMainState patrolState = new EnemyPatrolState();

    void Start()
    {
        startPosition = gameObject.transform;
        currentState = idleState;

        currentState.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this, collision);
    }

    public void SwitchState(EnemyMainState state)
    {
        currentState.Exit(this);
        currentState = state;
        currentState.Enter(this);
    }
}
