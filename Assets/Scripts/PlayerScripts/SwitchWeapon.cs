using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [Header("Weapons: ")]
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject Rifle;
    [SerializeField] private GameObject Knife;
    [Space]
    [Header("References: ")]
    /* USED FOR PLAYER MODEL ANIMATION */
    public Animator playerAnimator;

    void Start()
    {
        //playerAnimator.SetInteger("WeaponType", 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Gun.SetActive(true);
            Rifle.SetActive(false);
            Knife.SetActive(false);
            //playerAnimator.SetInteger("WeaponType", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Gun.SetActive(false);
            Rifle.SetActive(true);
            Knife.SetActive(false);
            //playerAnimator.SetInteger("WeaponType", 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Gun.SetActive(false);
            Rifle.SetActive(false);
            Knife.SetActive(true);
            //playerAnimator.SetInteger("WeaponType", 3);
        }
    }
}
