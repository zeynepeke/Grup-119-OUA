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


    private float targetValue = 1.0f; // Varsayýlan baþlangýç deðeri (1.0f: Tam aðýrlýk)

    public float TargetValue
    {
        get { return targetValue; }
        set
        {
            targetValue = Mathf.Clamp01(value); // 0 ile 1 arasýnda sýnýrla
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
