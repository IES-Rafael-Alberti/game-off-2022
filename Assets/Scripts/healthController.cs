using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
   
{
    public int health;

    private Animator animationChar;

    private void Reset()
    {
        health = 3;
    }

    public void RecieveDamage(int damage)
    {
         health=-damage;

    }

    public bool IsDead()
    {
        if (health > 0)
        {
            return false;  
        }
        else
        {
            //Implemented with Transition -> animationChar.SetBool("isDead", true);
            animationChar.Play("Death");
            this.gameObject.SetActive(false);
            return true;
        }
    }
}
