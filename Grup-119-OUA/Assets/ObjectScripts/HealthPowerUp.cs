using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public int healthBoostAmount = 10; // Can artýþý miktarý
    public ParticleSystem healingVFX;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")) // Sadece oyuncu temas ettiðinde
        {
            // Oyuncu karakterinin saðlýðýna eriþim
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.AddHealth(healthBoostAmount); // Can ekleme
                Debug.Log("can artýyor");
                playerHealth.AddHealth(healthBoostAmount);
                playerHealth.Update();
                Debug.Log("bar artýyo");
                //Destroy(gameObject); // Power-up'ý yok et
                gameObject.SetActive(false);
            }


            if (healingVFX != null)
            {
                healingVFX.Play();

                // VFX'i 2 saniye sonra durdur (örnek süre)
                Invoke("StopHealingVFX", 2f);
            }

        }
    }

    private void StopHealingVFX()
    {
        healingVFX.Stop();
    }
}
