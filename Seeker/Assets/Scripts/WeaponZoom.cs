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

    bool zoomInToggle = false;

    void OnDisable()
    {
        scope.m_Lens.FieldOfView = defaultFOV;
    }


    void Start()
    {
        scope.m_Lens.FieldOfView = defaultFOV;
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
                zoomInToggle = false;
            }
            else{
                scope.m_Lens.FieldOfView = zoomInFOV;
                zoomInToggle = true;
            }
        }
    }
}
