using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public int healthBoostAmount = 10; // Can art��� miktar�
    public ParticleSystem healingVFX;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")) // Sadece oyuncu temas etti�inde
        {
            // Oyuncu karakterinin sa�l���na eri�im
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.AddHealth(healthBoostAmount); // Can ekleme
                Debug.Log("can art�yor");
                playerHealth.AddHealth(healthBoostAmount);
                playerHealth.Update();
                Debug.Log("bar art�yo");
                //Destroy(gameObject); // Power-up'� yok et
                gameObject.SetActive(false);
            }


            if (healingVFX != null)
            {
                healingVFX.Play();

                // VFX'i 2 saniye sonra durdur (�rnek s�re)
                Invoke("StopHealingVFX", 2f);
            }

        }
    }

    private void StopHealingVFX()
    {
        healingVFX.Stop();
    }
}
