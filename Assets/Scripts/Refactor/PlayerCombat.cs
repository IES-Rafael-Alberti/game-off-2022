using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject attackHitBox;
    public float animationTime;
    public float cooldown = 0.01f;

    private PlayerMovement player;
    private bool isAttacking = false;
    public float radius;
    public Transform circleOrigin;

    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            HealthManager health;
            if(health = collider.GetComponent<HealthManager>())
            {
                health.GetHit(1, gameObject);
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && !isAttacking && player.CanMove())
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        GetComponentInChildren<Animator>().SetBool("isAttacking", true);
        yield return new WaitForSeconds(animationTime);
        GetComponentInChildren<Animator>().SetBool("isAttacking", false);
        yield return new WaitForSeconds(cooldown);
        isAttacking = false;
    }
}
