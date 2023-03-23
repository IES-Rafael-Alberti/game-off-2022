using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincessBehaviour : MonoBehaviour
{
    public float deathAnimation1Time = 0.5f;
    public float deathAnimation2Time = 2f;

    public bool isVulnerable = true;

    public bool isTransformed = false;
    public float itsTransformingTime = 2f;
    public bool isFlying = false;
    public bool isAttack1 = false;
    public bool isAttack2 = false;
    public bool isAttack3 = false;
    public bool isDead = false;

    public bool available = false;

    public Transform[] teleportPositions;
    public Transform[] attack2Positions;
    public float teleportAnimationTimer = 1f;
    public bool isTeleporting = false;

    public float offsetProyectile = 2f;

    public float attack1AnimationTimer = 1f;
    public float attack2AnimationTimer = 1f;
    public float attack3AnimationTimer = 1f;
    public float attack1Cooldown = 1f;
    public float attack2Cooldown = 1f;
    public float attack3Cooldown = 1f;
    public float attack3ProyectileSpeed = 4;

    private Vector3[] attack2ProyectileDirections = { Vector3.down, Vector3.up, Vector3.right, Vector3.left, new Vector3(1, 1, 0).normalized, new Vector3(-1, 1, 0).normalized, new Vector3(1, -1, 0).normalized, new Vector3(-1, -1, 0).normalized };
    private Vector3 proyectileDirection;
    private Transform player;
    private Vector3 myTeleportPosition;
    private int lastTeleportIndex = -1;
    private float initialHeatlth;
    private int teleportIndex = -1;
    private int randomAtack = 0;
    private EnemyHealth princessHealth;
    private int attack2ExclusionIndex;
    private ProyectileBehaviour proyectile;
    [SerializeField] ProyectileBehaviour proyectilePrefab;
    private LoadManager loadManager;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        princessHealth = GetComponent<EnemyHealth>();
        myTeleportPosition = transform.position;
        initialHeatlth = princessHealth.health;
        loadManager = GameObject.Find("Load Manager").GetComponent<LoadManager>();
    }
    void Update()
    {
        transform.localScale = new Vector3(Mathf.Sign(player.position.x - transform.position.x), 1, 1);

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
        if (isVulnerable && princessHealth.health != 1) {
            princessHealth.InvokeRecieveDamage(1);
            StartCoroutine(Teleport());
        } else 
        if (isVulnerable)
            {
                isVulnerable = false;
                available = false;
                isAttack1 = false;
                isAttack2 = false;
                isAttack3 = false;
                isDead = true;
                StartCoroutine(PrincessDeath());
            }
    }

    IEnumerator PrincessDeath()
    {
        yield return new WaitForSeconds(deathAnimation1Time);
        isDead = false;
        player.gameObject.GetComponent<PlayerHealth>().InvokeHeal(5);
        yield return new WaitForSeconds(deathAnimation2Time);
        loadManager.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        isAttack1 = true;
        yield return new WaitForSeconds(attack1AnimationTimer);
        if (isAttack1)
        {
            isAttack1 = false;
            proyectileDirection = new Vector3(player.position.x - transform.position.x, player.position.y - transform.position.y, 0).normalized;
            proyectile = Instantiate(proyectilePrefab, new Vector3(transform.localScale.x * offsetProyectile + transform.position.x, transform.position.y, 0), new Quaternion(), gameObject.transform);
            proyectile.transform.parent = null;
            if (proyectileDirection.x < 0) {
                proyectile.transform.localScale = new Vector3(-proyectile.transform.localScale.x, proyectile.transform.localScale.y, 1);
            }
            proyectile.direction = proyectileDirection;
            yield return new WaitForSeconds(attack1Cooldown);
            available = true;
        }
    }
    IEnumerator Attack3()
    {
        isAttack3 = true;
        yield return new WaitForSeconds(attack3AnimationTimer);
        if (isAttack3)
        {
            isAttack3 = false;
            attack2ExclusionIndex = Random.Range(0,8);
            proyectileDirection = Vector3.down;
            for (int i = 0; i < 8; i++)
            {
                if (i == attack2ExclusionIndex) continue;
                proyectile = Instantiate(proyectilePrefab, attack2Positions[i].position, new Quaternion(), gameObject.transform);
                proyectile.transform.parent = null;
                proyectile.speed = attack3ProyectileSpeed;
                proyectile.transform.localScale = new Vector3(4,4,1);
                proyectile.direction = proyectileDirection;
            }
            yield return new WaitForSeconds(attack3Cooldown);
            available = true;
        }
    }
    IEnumerator Attack2()
    {
        isAttack2 = true;
        yield return new WaitForSeconds(attack2AnimationTimer);
        if (isAttack2)
        {
            isAttack2 = false;
            for (int i = 0; i < 8; i++)
            {
                proyectile = Instantiate(proyectilePrefab, transform.position, new Quaternion(), gameObject.transform);
                proyectile.isAttack2 = true;
                proyectile.transform.parent = null;
                proyectile.transform.localScale = new Vector3(0.2f, 0.2f, 1);
                proyectile.direction = attack2ProyectileDirections[i];
            }
            yield return new WaitForSeconds(attack2Cooldown);
            available = true;
        }
    }

    IEnumerator Teleport()
    {
        isVulnerable = false;
        isAttack1 = false;
        isAttack2 = false;
        isAttack3 = false;
        available = false;
        isTeleporting = true;
        int tempTeleportIndex;
        do
        {
            tempTeleportIndex = Random.Range(0, Mathf.FloorToInt(initialHeatlth) - Mathf.FloorToInt(princessHealth.health));
        } while (tempTeleportIndex == teleportIndex || tempTeleportIndex == lastTeleportIndex);

        lastTeleportIndex = teleportIndex;
        teleportIndex = tempTeleportIndex;
        myTeleportPosition = teleportPositions[teleportIndex].position;
        teleportPositions[teleportIndex].gameObject.SetActive(true);
        yield return new WaitForSeconds(teleportAnimationTimer);
        transform.position = myTeleportPosition;

        if (teleportIndex == 2 || teleportIndex == 5 || teleportIndex == 6) isFlying = true;
        else isFlying = false;

        isTeleporting = false;
        teleportPositions[teleportIndex].gameObject.SetActive(false);
        yield return new WaitForSeconds(teleportAnimationTimer);
        available = true;
        isVulnerable = true;
        StopAllCoroutines();
    }
}
