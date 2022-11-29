using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class PrincessBehaviour : MonoBehaviour
{
    public float invulnerabilityTime = 2f;
    public bool isVulnerable = true;

    public bool isTransformed = false;
    public float itsTransformingTime = 2f;
    public bool isFlying = false;
    public bool isAttack1 = false;
    public bool isAttack2 = false;
    public bool isAttack3 = false;

    public bool available = false;

    public Transform[] teleportPositions;
    public float teleportAnimationTimer = 1f;
    public bool isTeleporting = false;

    public float attack1Cooldown = 3f;
    public float attack2Cooldown = 3f;
    public float attack3Cooldown = 3f;

    private Vector3 myTeleportPosition;
    private int teleportIndex = 0;
    private int randomAtack = 0;
    private EnemyHealth princessHealth;

    void Start()
    {
        princessHealth = GetComponent<EnemyHealth>();
        myTeleportPosition = transform.position;
    }
    void Update()
    {
        if (available)
        {
            if (!isTeleporting) {
                switch (princessHealth.health)
                {
                    case <= 3:
                        randomAtack = Random.Range(1, 3);
                        break;
                    case <= 5:
                        randomAtack = Random.Range(0, 2);
                        break;
                    default:
                        randomAtack = 0;
                        break;
                }
                ChooseAttack();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.CompareTag("PlayerHitbox"))
        if (isVulnerable) {
            princessHealth.RecieveDamage(1);
            StartCoroutine(Teleport());
            StartCoroutine(SetVulnerable());
        }
    }
    private void ChooseAttack()
    {
        available = false;
        switch (randomAtack)
        {
            case 0:
                StartCoroutine(Attack1());
                break;
            case 1:
                StartCoroutine(Attack3());
                break;
            case 2:
                StartCoroutine(Attack2());
                break;
        }

    }
    IEnumerator Attack1()
    {
        //Available 7-3 hp
        isAttack1 = true;
        Debug.Log("ataque 1");
        yield return new WaitForSeconds(attack1Cooldown);
        if (isAttack1)
        isAttack1 = false;
        available = true;
    }
    IEnumerator Attack3()
    {
        //Available 5-0 hp
        isAttack3 = true;
        Debug.Log("ataque 3");
        yield return new WaitForSeconds(attack3Cooldown);
        isAttack3 = false;
        available = true;
    }
    IEnumerator Attack2()
    {
        //Available 3-0 hp
        isAttack2 = true;
        Debug.Log("ataque 2");
        yield return new WaitForSeconds(attack2Cooldown);
        isAttack2 = false;
        available = true;
    }

    IEnumerator Teleport()
    {
        isAttack1 = false;
        isAttack2 = false;
        isAttack3 = false;
        available = false;
        isTeleporting = true;

        teleportIndex = Random.Range(0, 8 -Mathf.FloorToInt(princessHealth.health));
        while (myTeleportPosition == teleportPositions[teleportIndex].position)
        {
            teleportIndex = Random.Range(0, 8 - Mathf.FloorToInt(princessHealth.health));
            
        }
        if (princessHealth.health == 1) teleportIndex = 7;
        myTeleportPosition = teleportPositions[teleportIndex].position;

        yield return new WaitForSeconds(teleportAnimationTimer);
        transform.position = myTeleportPosition;
        yield return new WaitForSeconds(teleportAnimationTimer);
        available = true;
        isTeleporting = false;
    }
    IEnumerator SetVulnerable() {
        isVulnerable = false;
        yield return new WaitForSeconds(invulnerabilityTime);
        isVulnerable = true;
    }
}
