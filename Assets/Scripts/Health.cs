using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
    [HideInInspector] public const int maxHealth = 100;
    [Range(0, 100)]
    public int currentHealth;

    public AudioSource hitSound;
   
	void Start()
    {
        hitSound = GetComponent<AudioSource>();
        currentHealth = maxHealth;
	}
    
    virtual public void TakeDamage(int damageAmount)
    {
        hitSound.Play();
        currentHealth -= damageAmount;
    }

    virtual public void IncreaseHealth(int increaseAmount)
    {
        currentHealth += increaseAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }



    
}
