using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    [SerializeField] int amount = 10;
    [SerializeField] TMP_Text ammoTextCanvas;
    [SerializeField] AmmoSlot[] ammoSlots;
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }


    void Update()
    {
        DisplayAmmoText();
        ChangeTextColor();
    }

    private void DisplayAmmoText()
    {
        int equipWeapon = FindObjectOfType<WeaponSwitch>().GetCurrentWeapon();
        ammoTextCanvas.text = ammoSlots[equipWeapon].ammoAmount.ToString();
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void IncreaseAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }

    private void ChangeTextColor()
    {
        if(amount < 4)
        {
            ammoTextCanvas.color = Color.red;
        }
        else{
            ammoTextCanvas.color = Color.yellow;
        }
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
