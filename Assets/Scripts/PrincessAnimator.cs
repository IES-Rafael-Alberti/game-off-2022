using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator properties;
    private PrincessBehaviour princess;
    void Start()
    {
        properties = GetComponent<Animator>();
        princess = transform.parent.GetComponent<PrincessBehaviour>();
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

    }
}
