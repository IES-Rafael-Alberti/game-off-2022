using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerHealth;

public interface IHealth {

    public abstract void RecieveDamage(object sender, OnRecieveDamageEventArgs e);

    public abstract void Heal(object sender, OnHealEventArgs e);

    public abstract float GetActualHealth();

    public void InvokeRecieveDamage(float damage);

    public void InvokeHeal(float healAmount);

}
