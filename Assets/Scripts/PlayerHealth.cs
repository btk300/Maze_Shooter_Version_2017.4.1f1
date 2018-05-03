using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health {
    public Image healthBar;
    public GameEngine gameEngine;
    public void Update()
    {
        healthBar.fillAmount = currentHealth/100f;
    }

    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        if (currentHealth <= 0)
        {
            gameEngine.GameOver();
        }
    }

    public override void IncreaseHealth(int increaseAmount)
    {
        base.IncreaseHealth(increaseAmount);
    }
}
