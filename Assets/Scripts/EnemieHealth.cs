using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHealth : Health {
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
