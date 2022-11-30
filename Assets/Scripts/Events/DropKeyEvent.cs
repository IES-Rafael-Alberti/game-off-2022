using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DropKeyEvent : MonoBehaviour
{

    public GameObject key;
    public float itemAmount;
    private Vector3 golemLocation;
    private float golemHealth;

    

    void Start()
    {
        golemHealth = GetComponent<EnemyHealth>().health;
        itemAmount = 1f;
    }

    void Update()
    {
        golemHealth = GetComponent<EnemyHealth>().health;
        golemLocation = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        if (golemHealth <= 0) DropKey();
    }

    public void DropKey()
    {
        if (itemAmount > 0)
        {
            itemAmount--;
            key.transform.SetPositionAndRotation(golemLocation, Quaternion.identity);
            key.SetActive(true);
        }
    }
}
