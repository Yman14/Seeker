using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{

    [SerializeField] float timeTillDestroy = 4f;
    [SerializeField] [Range(10f, 50f)] float speed = 10f;


    Rigidbody rb;
    Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = FindObjectOfType<Weapon>();
        if (weapon == null)
        {
            Debug.Log("weapon not found!");
        }


        rb = GetComponent<Rigidbody>();
        //rb.velocity = transform.right * speed;
        //BulletPath();
        
        Destroy(gameObject, timeTillDestroy);
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

    public void BulletPath()
    {
        Transform target = weapon.Target;
        if (target != null)
        {
            transform.LookAt(target.position);
            // Calculate the direction from the bullet to the target
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            // Set the bullet's velocity to move towards the target
            rb.velocity = directionToTarget * speed;

        }
    }

    
}
