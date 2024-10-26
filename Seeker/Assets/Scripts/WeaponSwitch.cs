using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    void Update()
    {
        int previousWeapon = currentWeapon;
        SetWeaponActive();

        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }
    
    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //scrollwheel up
            if (currentWeapon >= transform.childCount-1)
            {
                currentWeapon = 0;
            }
            else{
                currentWeapon++;
            }

            //scrollwheel down
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount-1;
            }
            else{
                currentWeapon--;
            }
        }

    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else{
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    public int GetCurrentWeapon()
    {
        return currentWeapon;
    }
}
