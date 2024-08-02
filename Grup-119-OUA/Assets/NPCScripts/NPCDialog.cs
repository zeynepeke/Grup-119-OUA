using UnityEngine;
//using UnityEngine.UI;
using TMPro;


public class NPCDialog : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public Animator animator;
    public string konusmaMetni; // = "Merhaba macerac�! G�revin hakk�nda bilgi almak ister misin?";
    public float etkilesimMesafesi = 2f; // Etkile�im mesafesi
    public GameObject dialogPanel; // Diyalog panelini referans edecek de�i�ken


    private bool konusuyor = false;
    public Transform playerTransform; // Oyuncu karakterinin transform bile�eni

    void Start()
    {
        // Oyuncu karakterinin Transform bile�enini bul
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        dialogText = GameObject.Find("Dialog").GetComponent<TextMeshProUGUI>();
        dialogPanel.SetActive(false); // Ba�lang��ta diyalog panelini gizle
    }

    void Movement()
    {
        if (!konusuyor) // E�er konu�ma aktif de�ilse
        {
            // Hareket kodlar�
        }
    }


    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, playerTransform.position);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (mesafe <= etkilesimMesafesi) // NPC'nin yan�ndaysa
            {
                if (!konusuyor) // Konu�ma ba�lamam��sa
                {
                    // dialogText.text = konusmaMetni;
                    dialogText.gameObject.SetActive(true);
                    animator.SetTrigger("Talk");
                    konusuyor = true;
                    dialogPanel.SetActive(true); // Diyalog panelini g�ster
                }
                else // Konu�ma devam ediyorsa
                {
                    dialogText.gameObject.SetActive(false);
                    animator.SetBool("Talk", false); // Konu�ma bitti�inde "Konusuyor" parametresini false yap
                    konusuyor = false;
                    dialogPanel.SetActive(false); // Diyalog panelini gizle
                }
            }
        }

        // NPC'den uzakla��nca veya konu�ma bitince Idle animasyonuna ge�
        if (mesafe > etkilesimMesafesi || !konusuyor)
        {
            dialogText.gameObject.SetActive(false);
            dialogPanel.SetActive(false); // Diyalog panelini gizle
            animator.SetBool("Talk", false); // "Konusuyor" parametresini false yap
        }
    }
}
