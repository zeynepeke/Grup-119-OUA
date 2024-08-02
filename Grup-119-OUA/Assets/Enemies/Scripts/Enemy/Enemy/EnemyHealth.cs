using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Düşmanın maksimum canı
    public int currentHealth;   // Düşmanın mevcut canı

    public GameObject olumEfektPrefab; // Ölüm efekti için bir prefab (opsiyonel)
    private Animator animator; // Animasyonları kontrol etmek için Animator bileşeni

    private void Start()
    {
        currentHealth = maxHealth; // Başlangıçta canı maksimum yap
        animator = GetComponent<Animator>(); // Animator bileşenini al
    }

    public void HasarAl(int damageAmount)
    {
        currentHealth -= damageAmount;  // Hasar miktarını canından düş

        // Opsiyonel: Can azaldığında veya düşman ölünce bir animasyon oynat
        if (animator != null)
        {
            if (currentHealth <= 0)
            {
                animator.SetTrigger("Olum");
            }
            else
            {
                animator.SetTrigger("HasarAl");
            }
        }

        if (currentHealth <= 0)
        {
            Ol();
        }
    }

    private void Ol()
    {
        // Ölüm efekti oluştur (opsiyonel)
        if (olumEfektPrefab != null)
        {
            Instantiate(olumEfektPrefab, transform.position, Quaternion.identity);
        }

        // Düşmanı yok et
        Destroy(gameObject);
    }
}