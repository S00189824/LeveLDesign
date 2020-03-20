using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float Health = 1.0f;

    public void ApplyDamage(float amount)
    {
        Health -= amount;

        if (Health <= 0)
            Destroy(gameObject);
    }
}
