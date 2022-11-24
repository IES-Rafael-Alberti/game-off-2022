using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.UI.Image;

public class EnemyBehavior : MonoBehaviour
{
    public int speed;
    public Vector3 endPosition;
    public GameObject attackHitBox;
    public Vector2 lookingAt;
    public float cooldown = 1;
    public Vector2 offset = new Vector2(-0, -0);
    public float range = 1;
    public float animationSeconds = 1;

    private Vector3 startPosition;
    private bool goingLeft = true;
    private Rigidbody2D physics;
    private RaycastHit2D[] laserHits;
    private Vector2 origin;
    private bool isAttacking = false;
    void Start()
    {
        physics = GetComponent<Rigidbody2D>(); 
        startPosition = transform.position;
        endPosition = transform.position + endPosition; 
    }

    void Update()
    {
        MoveEnemy();
        
        // Negative Scale for flipping enemy
        if (physics.velocity.x > 0) {
            transform.localScale = new Vector3(-1, 1, 1) ;
        } else if (physics.velocity.x < 0) { 
            transform.localScale = Vector3.one;
        }

        //animator.SetBool("isAttacking", isAttacking);
        origin = new Vector2(transform.position.x + offset.x * transform.localScale.x, transform.position.y + offset.y);
        laserHits = Physics2D.RaycastAll(origin, lookingAt * transform.localScale.x, range);
        Debug.DrawRay(origin, lookingAt * transform.localScale.x * range, Color.red);
        if (!isAttacking)
            foreach (var hit in laserHits)
            {
                if (hit.collider == null) continue;
                if (hit.collider.tag == "Player") StartCoroutine(Attack());
            }
    }

    private void MoveEnemy()
    {
        Vector3 targetPosition = (goingLeft) ? endPosition : startPosition;
        if (!isAttacking)
            physics.velocity = (goingLeft) ? new Vector2(-speed, physics.velocity.y) : new Vector2(speed, physics.velocity.y);
        else physics.velocity = Vector2.zero;

        if (goingLeft)
        if (transform.position.x <= targetPosition.x) goingLeft = !goingLeft;
        if (!goingLeft)
        if (transform.position.x >= targetPosition.x) goingLeft = !goingLeft;
    }
    IEnumerator Attack()
    {
        isAttacking = true;
        attackHitBox.SetActive(true);
        //sprite.SetBool("isAttacking", isAttacking);
        yield return new WaitForSeconds(animationSeconds);
        attackHitBox.SetActive(false);
        yield return new WaitForSeconds(cooldown);
        isAttacking = false;
        //sprite.SetBool("isAttacking", isAttacking);
    }
}
