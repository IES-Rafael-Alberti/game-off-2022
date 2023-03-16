using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IHealth {

    public float health;
    public float gameOverAnimation = 1f;
    public float gameOverScreenTimer = 1f;
    public bool isHit = false;
    public GameObject gameOverCanvas;
    public LoadManager loadManager;
    public float initialHealth;
    public float hitAnimationSeconds = 1f;

    public RefactoredHealthBar healthBar;

    private event EventHandler<OnRecieveDamageEventArgs> OnRecieveDamage;
    public class OnRecieveDamageEventArgs : EventArgs {
        public float damage;
    }
    private event EventHandler<OnHealEventArgs> OnHeal;
    public class OnHealEventArgs : EventArgs
    {
        public float healAmount;
    }

    private void Start()
    {
        initialHealth = health;
        OnRecieveDamage += RecieveDamage;
        OnHeal += Heal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Death")
        {
            if (health > 0)
            {
                health = 0;
                StartCoroutine(GameOver());
            }
        }
    }

    IEnumerator HitAnimation()
    {
        isHit = true;
        yield return new WaitForSeconds(hitAnimationSeconds);
        isHit = false;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(gameOverAnimation);
        gameOverCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(gameOverScreenTimer);
        gameOverCanvas.gameObject.SetActive(false);
        loadManager.ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RecieveDamage(object sender, OnRecieveDamageEventArgs e) {
        if (health > 0)
        {
            health -= e.damage;
            StartCoroutine(HitAnimation());
            if (health <= 0)
            {
                health = 0;
                StartCoroutine(GameOver());
            }
            if (health > initialHealth) health = initialHealth;
        }
    }

    public void Heal(object sender, OnHealEventArgs e) {
        health += e.healAmount;
        if (health > initialHealth) health = initialHealth;
    }

    public float GetActualHealth() {
        return health;
    }

    public void InvokeRecieveDamage(float damage) {
        OnRecieveDamage?.Invoke(this, new OnRecieveDamageEventArgs {damage = damage});
    }

    public void InvokeHeal(float healAmount)
    {
        OnHeal?.Invoke(this, new OnHealEventArgs { healAmount = healAmount });
    }

}
