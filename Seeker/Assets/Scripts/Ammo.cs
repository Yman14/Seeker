using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    [SerializeField] int amount = 10;
    [SerializeField] TMP_Text ammoTextCanvas;

    void Update()
    {
        ammoTextCanvas.text = amount.ToString();
        ChangeTextColor();
    }

    public int GetCurrentAmmo()
    {
        return amount;
    }

    public void ReduceAmmo()
    {
        amount--;
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
}
