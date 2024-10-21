using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using StarterAssets;


public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera scope;
    [Tooltip("player camera field of view")]

    [SerializeField] [Range(10, 100f)] float defaultFOV = 40f;
    [SerializeField] [Range(10f, 30f)] float zoomInFOV = 20f;
    [SerializeField] [Range(0.1f, 5f)] float defaultSens = 1f;
    [SerializeField] [Range(0.1f, 5f)] float zoomInSens = 0.5f;

    bool zoomInToggle = false;
    FirstPersonController sensitivity;
    [Tooltip("player mouse sensitivity")]

    void Start()
    {
        sensitivity = GetComponent<FirstPersonController>();
        scope.m_Lens.FieldOfView = defaultFOV;
        sensitivity.RotationSpeed = defaultSens;
    }

    void Update()
    {
        zoomScope();
    }

    void zoomScope()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(zoomInToggle)
            {
                scope.m_Lens.FieldOfView = defaultFOV;
                sensitivity.RotationSpeed = defaultSens;
                zoomInToggle = false;
            }
            else{
                scope.m_Lens.FieldOfView = zoomInFOV;
                sensitivity.RotationSpeed = zoomInSens;
                zoomInToggle = true;
            }
        }
    }
}
