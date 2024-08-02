using UnityEngine;

public class KarakterSaldiri : MonoBehaviour
{
    public Animator animator; // Karakterin Animator bileşeni
    public Transform saldiriNoktasi; // Kılıcın hasar vereceği noktanın Transform'u
    public float saldiriMenzili = 1.0f; // Kılıcın etkili menzili
    public LayerMask dusmanKatmani; // Düşmanların bulunduğu katman

    private int baseAttack; // Karakterin temel atak gücü (Start() içinde ayarlanacak)1
    private int currentAttack; // Şu anki atak gücü (power-up ile değişebilir)1
    private float boostEndTime; // Güçlendirmenin biteceği zaman1

    public int minHasar = 5; // Minimum hasar
    public int maxHasar = 12; // Maksimum hasar

    public Silahlanma silahlanmaScript; // Silahlanma scriptine referans

    private void Start()
    {
        // Silahlanma scriptine referansı al
        silahlanmaScript = GetComponent<Silahlanma>();
        baseAttack = maxHasar; // Başlangıçta mevcut hasarı temel hasar olarak alıyoruz1
        currentAttack = baseAttack; //1
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && silahlanmaScript.isStrafe == true && silahlanmaScript.canAttack == true) // Sol fare tuşuna basıldığında VE kılıç kuşanılmışsa
        {
            Saldir();
        }

        // Güçlendirme süresi kontrolü
        if (Time.time > boostEndTime)
        {
            currentAttack = baseAttack; // Güçlendirme süresi doldu, normale dön
            
        } //1
    }

    public void BoostAttack(int boostAmount, float boostDuration)
    {
        currentAttack += boostAmount;
        boostEndTime = Time.time + boostDuration;
    }
        void Saldir()
    {

        // Saldırı animasyonunu oynat
        animator.SetTrigger("Attack");

        // Kılıcın menzilindeki düşmanları tespit et
        Collider[] vurulanDusmanlar = Physics.OverlapSphere(saldiriNoktasi.position, saldiriMenzili, dusmanKatmani);

        // Tespit edilen düşmanlara hasar ver
       
        {
           
            foreach (Collider dusman in vurulanDusmanlar)
            {
                // Hasar değerini rastgele belirle (burada tanımlayın)
                int hasar = Random.Range(minHasar, currentAttack + 1); // Artık güçlendirilmiş hasar
                Debug.Log(hasar);


                EnemyHealth dusmanSaglik = dusman.GetComponent<EnemyHealth>();
                if (dusmanSaglik != null)
                {
                    dusmanSaglik.HasarAl(hasar);
                }
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
