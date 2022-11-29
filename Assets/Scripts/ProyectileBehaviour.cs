using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileBehaviour : MonoBehaviour
{

    public float speed;
    public Vector3 direction;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Invoke("UpdateDirection", 0.2f);
        
    }

    private void UpdateDirection() {
        transform.right = direction;
    } 

    void Update() {
        rb.velocity = direction * speed;
    }

}
