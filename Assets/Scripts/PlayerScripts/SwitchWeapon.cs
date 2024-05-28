using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [Header("Weapons: ")]
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject Rifle;
    [SerializeField] private GameObject Knife;



    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Gun.SetActive(true);
            Rifle.SetActive(false);
            Knife.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Gun.SetActive(false);
            Rifle.SetActive(true);
            Knife.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Gun.SetActive(false);
            Rifle.SetActive(false);
            Knife.SetActive(true);
        }
    }
}
