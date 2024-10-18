using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject HitVFXPrefab;
    [SerializeField] float range = 100f;
    [SerializeField] int weaponDamage = 40;

    Transform target;
    public Transform Target{    get { return target; }}

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            HitImpactVFX(hit);

            //call method from enemyhealth script to reduce damge taken
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(weaponDamage);
                Debug.Log("Enemy Health: " + enemy.Health);

            }
            target = hit.transform;
            //InstantiateBullet();
        }
        else { return; }
    }

    private void HitImpactVFX(RaycastHit hit)
    {
        GameObject hitEffect = Instantiate(HitVFXPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        Debug.Log("hitpoint: " + hit.point);
        Destroy(hitEffect, 2);
    }

    private void InstantiateBullet()
    {
        if(Instantiate(bulletPrefab, transform.position, Quaternion.identity))
        {
            //Debug.Log("Bullet instantiated at position " + transform.position);
        }
    }

}
