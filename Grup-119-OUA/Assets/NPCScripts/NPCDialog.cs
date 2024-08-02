using UnityEngine;
//using UnityEngine.UI;
using TMPro;


public class NPCDialog : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public Animator animator;
    public string konusmaMetni; // = "Merhaba maceracý! Görevin hakkýnda bilgi almak ister misin?";
    public float etkilesimMesafesi = 2f; // Etkileþim mesafesi
    public GameObject dialogPanel; // Diyalog panelini referans edecek deðiþken


    private bool konusuyor = false;
    public Transform playerTransform; // Oyuncu karakterinin transform bileþeni

    void Start()
    {
        // Oyuncu karakterinin Transform bileþenini bul
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        dialogText = GameObject.Find("Dialog").GetComponent<TextMeshProUGUI>();
        dialogPanel.SetActive(false); // Baþlangýçta diyalog panelini gizle
    }

    void Movement()
    {
        if (!konusuyor) // Eðer konuþma aktif deðilse
        {
            // Hareket kodlarý
        }
    }


    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, playerTransform.position);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (mesafe <= etkilesimMesafesi) // NPC'nin yanýndaysa
            {
                if (!konusuyor) // Konuþma baþlamamýþsa
                {
                    // dialogText.text = konusmaMetni;
                    dialogText.gameObject.SetActive(true);
                    animator.SetTrigger("Talk");
                    konusuyor = true;
                    dialogPanel.SetActive(true); // Diyalog panelini göster
                }
                else // Konuþma devam ediyorsa
                {
                    dialogText.gameObject.SetActive(false);
                    animator.SetBool("Talk", false); // Konuþma bittiðinde "Konusuyor" parametresini false yap
                    konusuyor = false;
                    dialogPanel.SetActive(false); // Diyalog panelini gizle
                }
            }
        }

        // NPC'den uzaklaþýnca veya konuþma bitince Idle animasyonuna geç
        if (mesafe > etkilesimMesafesi || !konusuyor)
        {
            dialogText.gameObject.SetActive(false);
            dialogPanel.SetActive(false); // Diyalog panelini gizle
            animator.SetBool("Talk", false); // "Konusuyor" parametresini false yap
        }
    }
}
