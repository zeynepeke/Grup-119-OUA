using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKLook : MonoBehaviour
{
    float weight;
    Animator anim;
    Camera mainCam;



    void Start()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
    }

    // Update is called once per frame


    private float targetValue = 1.0f; // Varsay�lan ba�lang�� de�eri (1.0f: Tam a��rl�k)

    public float TargetValue
    {
        get { return targetValue; }
        set
        {
            targetValue = Mathf.Clamp01(value); // 0 ile 1 aras�nda s�n�rla
        }
    }


    private void OnAnimatorIK(int LayerIndex) 
    {
        anim.SetLookAtWeight(targetValue, 5f, 1.3f, .5f, .5f);

        Ray lookAtRay = new Ray(transform.position, mainCam.transform.forward);
        anim.SetLookAtPosition(lookAtRay.GetPoint(20));
    }

    public void art()
    { 
    weight = Mathf.Lerp(weight, 1f, Time.deltaTime);
    }

    public void azal()
    {
        weight = Mathf.Lerp(weight, 0, Time.deltaTime);
    }
}
