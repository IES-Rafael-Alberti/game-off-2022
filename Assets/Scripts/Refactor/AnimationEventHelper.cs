using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHelper : MonoBehaviour
{
    public UnityEvent OnAttackPerformed, OnDamagedEnd, OnDeath;

    public void TriggerAttack()
    {
        OnAttackPerformed?.Invoke();
    }
    public void TriggerDamagedEnd()
    {
        OnDamagedEnd?.Invoke();
    }
    public void TriggerDeath()
    {
        OnDeath?.Invoke();
    }
}
