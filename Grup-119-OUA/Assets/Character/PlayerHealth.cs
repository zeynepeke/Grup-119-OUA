using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance; 
    public int maxHealth = 100;
    private int currentHealth;
    public Image healthBarImage;

    
    public void DecreaseHealth(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Karakter " + (maxHealth - currentHealth) + " hasar aldý!");
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        healthBarImage.fillAmount = (float)currentHealth / maxHealth;
        // Debug.Log("artýyor");
    }

    public void AddHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
