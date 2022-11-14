using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyBehavior : MonoBehaviour
{
    public int speed;
    public Vector3 endPosition;

    private Vector3 startPosition;
    public bool goingLeft = true;
    private Rigidbody2D physics;

    void Start()
    {
        physics = GetComponent<Rigidbody2D>(); 

        startPosition = transform.position;
        endPosition = transform.position + endPosition; 
    }

    void Update()
    {
        MoveEnemy();

        if (physics.velocity.x > 0) {
            transform.localScale = new Vector3(-1, 1, 1) ;
        } else if (physics.velocity.x < 0) { 
            transform.localScale = Vector3.one;
        }
    }

    private void MoveEnemy()
    {
        Vector3 targetPosition = (goingLeft) ? endPosition : startPosition;

        physics.velocity = (goingLeft) ?  new Vector2(-speed, physics.velocity.y) : new Vector2(speed, physics.velocity.y);

        if (goingLeft)
        if (transform.position.x <= targetPosition.x) goingLeft = !goingLeft;
        if (!goingLeft)
        if (transform.position.x >= targetPosition.x) goingLeft = !goingLeft;
    }

}
