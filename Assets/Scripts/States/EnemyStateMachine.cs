using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] public GameObject owner;

    EnemyMainState currentState;
    public EnemyIdleState idleState;

    void Start()
    {
        currentState = idleState;

        currentState.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    public void SwitchState(EnemyMainState state)
    {
        currentState.Exit(this);
        currentState = state;
        currentState.Enter(this);
    }
}
