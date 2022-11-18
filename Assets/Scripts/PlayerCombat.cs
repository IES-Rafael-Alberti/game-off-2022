using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject attackHitBox;
    public float animationTime;

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
            isAttacking = true;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(animationTime);
        isAttacking = false;
        attackHitBox.SetActive(false);
    }
}
