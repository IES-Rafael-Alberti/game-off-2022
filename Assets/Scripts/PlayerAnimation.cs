using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public float movingMargin = 0.1f;
    public float fallingMargin = 0.1f;
    public AudioClip deadsound;
    public AudioClip hitsound;
    public AudioClip attacksound;
    public AudioClip jumpsound;
    AudioSource audioPlayer;


    private PlayerMovement pm;
    private Rigidbody2D rb;
    private Animator properties;
    private PlayerCombat combatController;
    private PlayerHealth playerHealth;

    void Start()
    {
        pm = transform.parent.GetComponent<PlayerMovement>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
        properties = GetComponent<Animator>();
        combatController = transform.parent.GetComponent<PlayerCombat>();
        playerHealth = transform.parent.GetComponent<PlayerHealth>();
        audioPlayer = this.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        properties.SetBool("isMoving",Mathf.Abs(rb.velocity.x)>movingMargin);
        properties.SetBool("isFalling", pm.jumps < pm.initialJumps);
        properties.SetBool("isHit", playerHealth.isHit);
        properties.SetBool("isAttacking", combatController.attackHitBox.gameObject.activeSelf);
        properties.SetBool("isDead", playerHealth.health <= 0);

        if (properties.GetBool("isDead"))
            audioPlayer.clip = deadsound;
        else if (properties.GetBool("isHit"))
            audioPlayer.clip = hitsound;
        else if (properties.GetBool("isAttacking"))
            audioPlayer.clip = attacksound;
        else if (properties.GetBool("isFalling"))
           audioPlayer.clip = jumpsound;
    }

    //private void LateUpdate()
    //{
    //    if (properties.GetBool("isDead"))
    //    {
    //        audioPlayer.clip = deadsound;
    //        audioPlayer.Play();
    //    }
    //    else if (properties.GetBool("isHit")) { }
    //    else if (properties.GetBool("isAttacking")) { }
    //                else if (properties.GetBool("isFalling")) { }
        
    //}
}
