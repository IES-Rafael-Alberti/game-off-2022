using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    public bool isDead = false;

    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void GetHit(int damage, GameObject sender)
    {
        if (isDead)
            return;
        if (sender.layer == gameObject.layer)
            return;

        currentHealth -= damage;

        if (currentHealth > 0)
            OnHitWithReference?.Invoke(sender);
        else
        {
            OnDeathWithReference?.Invoke(sender);
            isDead = true;
            Destroy(this.gameObject);
        }
    }
}
