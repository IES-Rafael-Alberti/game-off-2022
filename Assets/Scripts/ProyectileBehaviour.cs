using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileBehaviour : MonoBehaviour
{

    public float speed = 8;
    public bool isAttack2 = false;
    public Vector3 direction;

    private Rigidbody2D rb;
    private float addScale = 0.1f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        transform.right = -direction;
    }

    void Update() {
        rb.velocity = direction * speed;

        if (isAttack2 && transform.localScale.x < 3) {
            transform.localScale = new Vector3(transform.localScale.x + addScale, transform.localScale.y + addScale, 1);
            if (transform.localScale.x > 3)
            {
                transform.localScale = new Vector3(3, 3, 1);
            }
        }
    }

}
