using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform WeaponOnHand, WeaponOnBack;
    [SerializeField] GameObject Weapon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Change_Weapon();
        Attack();
    }
    
    // Change transform of weapon
    void Change_Weapon()
    {
        if(Input.GetMouseButtonDown(2))
        {
            if (animator.GetBool("FightReady"))
            {
                animator.SetTrigger("WeaponOnBack");
            }
            else
            {
                animator.SetTrigger("WeaponOnHand");           
            }
        }
    }

    void Attack()
    {
        if(animator.GetBool("FightReady"))
        {
            if(Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    void Weapon_On_Hand()
    {
        Weapon.transform.SetParent(WeaponOnHand);
        Weapon.transform.localPosition = Vector3.zero;
        Weapon.transform.localRotation = Quaternion.identity;
        animator.SetBool("FightReady", true);

        Debug.Log("Get");
    }
       
    void Weapon_On_Mid()
    {

    }

    void Weapon_On_Back()
    {
        Weapon.transform.SetParent(WeaponOnBack);
        Weapon.transform.localPosition = Vector3.zero;
        Weapon.transform.localRotation = Quaternion.identity;
        animator.SetBool("FightReady", false);

        Debug.Log("Put");
    }
}
