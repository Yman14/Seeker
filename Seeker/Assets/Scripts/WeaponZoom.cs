using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerCamera;
    [SerializeField] [Range(10, 100f)] float defaultFOV = 40f;
    [SerializeField] [Range(10f, 30f)] float zoomIn = 20f;

    void Start()
    {
        playerCamera.m_Lens.FieldOfView = defaultFOV;
    }

    void Update()
    {
        zoomScope();
    }

    void zoomScope()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(playerCamera.m_Lens.FieldOfView == defaultFOV)
            {
                playerCamera.m_Lens.FieldOfView = zoomIn;
            }
            else{
                playerCamera.m_Lens.FieldOfView = defaultFOV;
            }
        }
    }
}
