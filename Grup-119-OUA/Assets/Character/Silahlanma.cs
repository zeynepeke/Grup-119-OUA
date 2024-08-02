using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silahlanma : MonoBehaviour
{

    public bool canAttack = true;
    public bool isStrafe = false;
    Animator Anim;

    public GameObject handWeapon;
    public GameObject backWeapon;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }


    void Update()
    {
        Anim.SetBool("iS", isStrafe);

        if (Input.GetKeyDown(KeyCode.F))
        {
            isStrafe = !isStrafe;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && isStrafe == true && canAttack == true)
        {
            Anim.SetTrigger("Attack");

        }


        if (isStrafe == true)
        {
            GetComponent<CharacterController>().hareketTipi = CharacterController.MovementType.Strafe;
            // GetComponent<IKLook>().azal();
            GetComponent<IKLook>().TargetValue += 0.1f;

        }

        if (isStrafe == false)
        {
            GetComponent<CharacterController>().hareketTipi = CharacterController.MovementType.Directional;
            //GetComponent<IKLook>().art();
            GetComponent<IKLook>().TargetValue -= 0.1f;

        }

    }

    void equip()
    {
        backWeapon.SetActive(false);
        handWeapon.SetActive(true);
    }

    void unequip()
    {
        backWeapon.SetActive(true);
        handWeapon.SetActive(false);

    }



}