using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerHealth;

public class EnemyHealth : MonoBehaviour, ITextInfo, IHealth
{
    public float health = 3;
    public float gameOverMargin = 1f;
    public float hitAnimationSeconds = 0.5f;
    public bool isHit;
    public bool isPrincess = false;

    private event EventHandler<OnRecieveDamageEventArgs> OnRecieveDamage;
    private event EventHandler<OnHealEventArgs> OnHeal;

    public void Start() {
        OnRecieveDamage += RecieveDamage;
        OnHeal += Heal;
    }

    IEnumerator HitAnimation()
    {
        isHit = true;
        yield return new WaitForSeconds(hitAnimationSeconds);
        isHit = false;
    }

    IEnumerator DeathAnimation()
    {
        if (!isPrincess)
        {
            yield return new WaitForSeconds(gameOverMargin);
            gameObject.SetActive(false);
        }
        else
        {
            yield return null;
        }
    }

    public string TextInfo()
    {
        return $"{health} lives left";
    }

    public void RecieveDamage(object sender, PlayerHealth.OnRecieveDamageEventArgs e) {
        health -= e.damage;
        StartCoroutine(HitAnimation());
        if (health <= 0) StartCoroutine(DeathAnimation());
    }

    public void Heal(object sender, PlayerHealth.OnHealEventArgs e) {}

    public float GetActualHealth() {
        return health;
    }

    public void InvokeRecieveDamage(float damage)
    {
        OnRecieveDamage?.Invoke(this, new OnRecieveDamageEventArgs { damage = damage });
    }

    public void InvokeHeal(float healAmount) {}
}
