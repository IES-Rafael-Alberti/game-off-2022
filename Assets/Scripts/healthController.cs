using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveDamage()
    {
        health--;
    }

    public bool IsAlive()
    {
        if (health >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
