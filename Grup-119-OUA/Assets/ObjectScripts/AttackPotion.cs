using UnityEngine;
using System.Collections;


public class AttackPowerUp : MonoBehaviour
{
    public int attackBoost = 5; // Atak gücü artýþý
    public float duration = 30f; // Güçlendirme süresi (saniye)
    public ParticleSystem attackVFX; // Atak VFX'i (Unity Editör'ünden atayýn)

    private bool isVFXPlaying = false; // VFX'in oynatýlýp oynatýlmadýðýný takip etmek için

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KarakterSaldiri karakterSaldiri = other.GetComponent<KarakterSaldiri>();

            if (karakterSaldiri != null)
            {
                karakterSaldiri.BoostAttack(attackBoost, duration);

                // VFX'i oynat ve 5 saniye sonra durdur
                if (attackVFX != null)
                {
                    Debug.Log("coroutine s1");
                    attackVFX.Play();
                    StartCoroutine(StopAttackVFXAfterDelay(5f)); // VFX'i 5 saniye sonra durdur
                    
                }

                Destroy(gameObject);
            }
        }
    }

    private IEnumerator StopAttackVFXAfterDelay(float delay)
    {
        Debug.Log("Coroutine started");

        yield return new WaitForSecondsRealtime(delay);


        Debug.Log("Stopping VFX");

        if (attackVFX != null && attackVFX.isPlaying) // VFX oynuyorsa durdur
        {
            attackVFX.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            isVFXPlaying = false;
        }

        Debug.Log("Coroutine finished at: " + Time.time);
    }
}