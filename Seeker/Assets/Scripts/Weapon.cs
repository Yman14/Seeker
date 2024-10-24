using System;
using System.Collections;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject HitVFXPrefab;
    [SerializeField] float range = 100f;
    [SerializeField] int weaponDamage = 40;
    [SerializeField] float timeBetweenShot = 1f;

    Ammo ammoSlot;
    Transform target;
    public Transform Target{    get { return target; }}
    bool canShoot = true;

    void OnEnable()
    {
        canShoot = true; // Reset the shooting state when the object is re-enabled
    }

    void Start()
    {
        ammoSlot = FindObjectOfType<Ammo>();
    }

    void Update()
    {
        Debug.Log("can shoot bug: " + canShoot);
        if(Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceAmmo();
        }
        yield return new WaitForSeconds(timeBetweenShot);
        canShoot = true;
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
            //target = hit.transform;
            //InstantiateBullet();
        }
        else { return; }
    }

    private void HitImpactVFX(RaycastHit hit)
    {
        GameObject hitEffect = Instantiate(HitVFXPrefab, hit.point, Quaternion.LookRotation(hit.normal));
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
