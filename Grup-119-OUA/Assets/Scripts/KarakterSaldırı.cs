using UnityEngine;

public class KarakterSaldiri : MonoBehaviour
{
    public Animator animator; // Karakterin Animator bileşeni
    public Transform saldiriNoktasi; // Kılıcın hasar vereceği noktanın Transform'u
    public float saldiriMenzili = 1.0f; // Kılıcın etkili menzili
    public LayerMask dusmanKatmani; // Düşmanların bulunduğu katman

    public int minHasar = 5; // Minimum hasar
    public int maxHasar = 12; // Maksimum hasar

    public Silahlanma silahlanmaScript; // Silahlanma scriptine referans

    private void Start()
    {
        // Silahlanma scriptine referansı al
        silahlanmaScript = GetComponent<Silahlanma>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && silahlanmaScript.isStrafe == true && silahlanmaScript.canAttack == true) // Sol fare tuşuna basıldığında VE kılıç kuşanılmışsa
        {
            Saldir();
        }
    }

    void Saldir()
    {
        // Saldırı animasyonunu oynat
        animator.SetTrigger("Attack");

        // Kılıcın menzilindeki düşmanları tespit et
        Collider[] vurulanDusmanlar = Physics.OverlapSphere(saldiriNoktasi.position, saldiriMenzili, dusmanKatmani);

        // Tespit edilen düşmanlara hasar ver
        foreach (Collider dusman in vurulanDusmanlar)
        {
            // Hasar değerini rastgele belirle
            int hasar = Random.Range(minHasar, maxHasar + 1); // (maxHasar + 1) dahildir

            // Düşmanın sağlığını etkileyecek bir fonksiyon çağır (örneğin, DusmanSaglik scriptindeki HasarAl fonksiyonu)
            EnemyHealth dusmanSaglik = dusman.GetComponent<EnemyHealth>();
            if (dusmanSaglik != null)
            {
                dusmanSaglik.HasarAl(hasar);
            }
        }
    }

    // (Opsiyonel) Saldırı noktasını görselleştirmek için
    void OnDrawGizmosSelected()
    {
        if (saldiriNoktasi == null)
            return;

        Gizmos.DrawWireSphere(saldiriNoktasi.position, saldiriMenzili);
    }
}
