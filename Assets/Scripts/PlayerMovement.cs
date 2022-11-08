using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;
    public float jumpForce = 17f;
    public float jumpMargin = 0.4f;

    private float inputX;
    private int jumps = 2;
    private int initialJumps;
    private Rigidbody2D physics;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        initialJumps = jumps;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Horizontal movement
        inputX = Input.GetAxis("Horizontal");
        physics.velocity = new Vector2(inputX * speed, physics.velocity.y);

        // Jump and Double jump code
        if (Input.GetAxis("Vertical") > 0 && jumps > 0 && Mathf.Abs(physics.velocity.y) < jumpMargin)
        {
            jumps -= 1;
            physics.velocity = new Vector2(physics.velocity.x, jumpForce);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Condition to refresh jumps (The collision object must have 'Ground' tag)
        if (collision.collider.CompareTag("Ground")) jumps = initialJumps;
    }
}
