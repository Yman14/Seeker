using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    public void HandleDeath()
    {
        gameOverCanvas.SetActive(true);

        //disbled weapon switching
        FindObjectOfType<WeaponSwitch>().enabled = false;

        //show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;    //pause the game //might be a bad code, not sure
    }
}
