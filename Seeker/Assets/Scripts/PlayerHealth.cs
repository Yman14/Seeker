using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    DeathHandler deathHandlerScript;
    [SerializeField] float HP = 100f;

    void Start()
    {
        deathHandlerScript = GetComponent<DeathHandler>();

        //lock and hide cursor after reset
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void TakeDamage(float damage)
    {
        HP -= damage;

        if(HP <= 0)
        {
            Debug.Log("Player Dead.");
            deathHandlerScript.HandleDeath();

        }
    }
}
