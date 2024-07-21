using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float inputX;
        float inputY;

        public Transform Model;

    Animator Anim;

    Vector3 StickDirection;

    Camera mainCam;

    public float damp;

    [Range(1, 20)]
    public float rotationSpeed;
    
    
    void Start()
    {
     
        Anim= GetComponent<Animator>();
        mainCam= Camera.main;

}

  
    private void LateUpdate()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        StickDirection = new Vector3 (inputX, 0, inputY);

        InputMove();
        InputRotation();
        
    }

    void InputMove()
    {
        Anim.SetFloat ("speed", Vector3.ClampMagnitude(StickDirection, 1).magnitude, damp, Time.deltaTime * 10);
    }

    void InputRotation()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(StickDirection);
        rotOfset.y = 0;

        Model.forward = Vector3.Slerp(Model.forward, rotOfset, Time.deltaTime * rotationSpeed);
    }
}
