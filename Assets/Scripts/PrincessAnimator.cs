using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator properties;
    private PrincessBehaviour princess;
    [SerializeField]
    private AudioClip hitSound;
    [SerializeField]
    private AudioClip attackSound;
    [SerializeField]
    private AudioClip transformSound;
    [SerializeField]
    private AudioClip tpSound;
    [SerializeField]
    private AudioClip deathSound;
    private AudioSource audioPlayer;

    void Start()
    {
        audioPlayer = this.GetComponent<AudioSource>();
        properties = GetComponent<Animator>();
        princess = transform.parent.GetComponent<PrincessBehaviour>();
        audioPlayer.clip = transformSound;
    }

    // Update is called once per frame
    void Update()
    {
        properties.SetBool("isTransformed", princess.isTransformed);
        properties.SetBool("isTeleporting", princess.isTeleporting);
        properties.SetBool("isAttack1", princess.isAttack1);
        properties.SetBool("isAttack2", princess.isAttack2);
        properties.SetBool("isAttack3", princess.isAttack3);
        properties.SetBool("isFlying", princess.isFlying);
        properties.SetBool("isDead", princess.isDead);

        if (properties.GetBool("isDead"))
            audioPlayer.clip = deathSound;
        else if (properties.GetBool("isTeleporting"))
            audioPlayer.clip = tpSound;
        else if (properties.GetBool("isAttack1"))
            audioPlayer.clip = attackSound;
        else if (properties.GetBool("isAttack2"))
            audioPlayer.clip = attackSound;
        else if (properties.GetBool("isAttack3"))
            audioPlayer.clip = attackSound;

    }
}
