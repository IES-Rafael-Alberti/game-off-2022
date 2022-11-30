using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileBehaviour : MonoBehaviour
{

    public float speed = 8;
    public Vector3 direction;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        transform.right = -direction;
    }

    void Update() {
        rb.velocity = direction * speed;
    }

}
