using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;
    public float jumpForce = 17f;
    public float jumpMargin = 0.4f;
    public int jumps = 2;
    public int initialJumps;

    private DefaultEvent[] events;
    private PlayerHealth playerHealth; 
    private float inputX;
    private Rigidbody2D physics;
    private bool acceptInput = true;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        initialJumps = jumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.health <= 0) acceptInput = false;
        if (acceptInput)
        {
            // Horizontal movement
            inputX = Input.GetAxis("Horizontal");
            physics.velocity = new Vector2(inputX * speed, physics.velocity.y);

            // Jump and Double jump code
            if (Input.GetButtonDown("Jump") && jumps > 0 && Mathf.Abs(physics.velocity.y) < jumpMargin)
            {
                jumps -= 1;
                physics.velocity = new Vector2(physics.velocity.x, jumpForce);

            }

            // Flip player
            if (inputX > 0) transform.localScale = Vector3.one;
            else if (inputX < 0) transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        { 
            if (playerHealth.health <= 0) physics.velocity = Vector2.zero;
            else physics.velocity = new Vector2(0, physics.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Condition to refresh jumps (The collision object must have 'Ground' tag)
        if (collision.collider.CompareTag("Ground")) jumps = initialJumps;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Event")) {
            events = collision.gameObject.GetComponents<DefaultEvent>();
            foreach (DefaultEvent lastEvent in events) if (lastEvent.enabled) lastEvent.EventOnEnter(this);
        } 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButton("Interact"))
        {
            if (collision.CompareTag("Event"))
            {
                events = collision.gameObject.GetComponents<DefaultEvent>();
                foreach (DefaultEvent lastEvent in events) if (lastEvent.enabled) lastEvent.EventOnStay(this);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Event"))
        {
            events = collision.gameObject.GetComponents<DefaultEvent>();
            foreach (DefaultEvent lastEvent in events) if (lastEvent.enabled) lastEvent.EventOnExit(this);
        }
    }

    public void StopInput()
    {
        acceptInput = false;
    }
    public void ReceiveInput()
    {
        acceptInput = true;
    }
    public bool CanMove()
    {
        return acceptInput;
    }
}
