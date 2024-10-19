using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject deathCanvas;
    [SerializeField] float HP = 100f;

    public void TakeDamage(float damage)
    {
        HP -= damage;

        if(HP <= 0)
        {
            Debug.Log("Player Dead.");
            deathCanvas.SetActive(true);
            Time.timeScale = 0f;    //pause the game //might be a bad code, not sure

        }
    }
}
