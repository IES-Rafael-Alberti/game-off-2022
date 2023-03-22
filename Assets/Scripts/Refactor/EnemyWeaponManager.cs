using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
    public float radius;
    public Transform circleOrigin;

    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            Debug.Log(collider);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }
}
