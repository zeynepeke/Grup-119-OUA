using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UI = UnityEngine.Input;

public class CharController : MonoBehaviour
{

    [Header("Metrics")]
    public float damp;
    [Range(1, 20)]
    public float rotationSpeed;

    [Range(1, 20)]
    public float StrafeTurnSpeed;

    float normalFov;
    public float SprintFov;

    float inputX;
    float inputY;
    float maxSpeed;

    public Transform Model;

    Animator Anim;
    Vector3 StickDirection;
    Camera mainCam;

    public KeyCode SprintButton = KeyCode.LeftShift;
    public KeyCode WalkButton = KeyCode.C;

    public enum MovementType
    { 
        Directional,
        Strafe

    };

    public MovementType hareketTipi;

   

    void Start()
    {
        Anim = GetComponent<Animator>();
        mainCam = Camera.main;
        normalFov = mainCam.fieldOfView;

    }

    private void LateUpdate()
    {
        //InputMove();
        //InputRotation();
        Movement();

    }

    void Movement()
    {

        if(hareketTipi == MovementType.Strafe)
        {
            inputX = UI.GetAxis("Horizontal");
            inputY = UI.GetAxis("Vertical");

            Anim.SetFloat("iX", inputX, damp, Time.deltaTime * 10);
            Anim.SetFloat("iY", inputY, damp, Time.deltaTime * 10);
            

            var hareketEdiyor = inputX != 0 || inputY != 0;
            
            if(hareketEdiyor) 
            {
                float yawCamera = mainCam.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), StrafeTurnSpeed * Time.fixedDeltaTime);
                Anim.SetBool("strafeMoving", true);

            }
            else 
            {
                Anim.SetBool("strafeMoving", false);
            }

        }



        if (hareketTipi == MovementType.Directional)
        {
            InputMove();
            InputRotation();
            //inputX = UI.GetAxis("Horizontal");
            //inputY = UI.GetAxis("Vertical");

            StickDirection = new Vector3(inputX, 0, inputY);

            if (UI.GetKey(SprintButton))
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, SprintFov, Time.deltaTime * 2);

                maxSpeed = 2;
                inputX = 2 * UI.GetAxis("Horizontal");
                inputY = 2 * UI.GetAxis("Vertical");


            }

            else if (UI.GetKey(WalkButton))
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                maxSpeed = 0.2f;
                inputX = UI.GetAxis("Horizontal");
                inputY = UI.GetAxis("Vertical");

            }


            else
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                maxSpeed = 1;
                inputX = UI.GetAxis("Horizontal");
                inputY = UI.GetAxis("Vertical");

            }

        }

    }

    void InputMove()
    {

        Anim.SetFloat("speed", Vector3.ClampMagnitude(StickDirection, maxSpeed).magnitude, damp, Time.deltaTime * 10); //clamp ortalamasýný almak için ve damp gecikme yapýyor
    }

    void InputRotation()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(StickDirection);
        rotOfset.y = 0;
        Model.forward = Vector3.Slerp(Model.forward, rotOfset, Time.deltaTime * rotationSpeed);
    }
    // Update is called once per frame
    

}
