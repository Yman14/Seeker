using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    public float Health{get {return health;}}

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }
    

    public void TakeDamage(int damage)
    {
        BroadcastMessage("OnDamageTaken");
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(!isDead)
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }
}
