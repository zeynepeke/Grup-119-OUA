using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBase : MonoBehaviour
{
    public int currentHealth;
    [SerializeField] private int maxHealth;

   
    public virtual void Awake()
    {
        currentHealth = maxHealth;
    }
    public void ChangeCurrentHealth(int value)
    {
        currentHealth += value;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

      

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseHealth(int value)
    {
        ChangeCurrentHealth(value);
    }

    public void DecreaseHealth(int value)
    {
        ChangeCurrentHealth(-value);
    }

    

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}