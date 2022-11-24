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
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(animationTime);
        attackHitBox.SetActive(false);
        yield return new WaitForSeconds(cooldown);
        isAttacking = false;
    }
}
