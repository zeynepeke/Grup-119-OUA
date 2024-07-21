using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxCan = 50;
    public int mevcutCan;

    void Start()
    {
        mevcutCan = maxCan;
    }

    public void HasarAl(int hasar)
    {
        mevcutCan -= hasar;

        if (mevcutCan <= 0)
        {
            Ol(); // Düşmanı yok eden fonksiyon
        }
        Debug.Log("hasar alıyor");
    }

    void Ol()
    {
        Destroy(gameObject); // Düşman objesini yok et
    }
}
