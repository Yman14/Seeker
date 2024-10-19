using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth player;
    [SerializeField] float damage = 20f;

    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }
    public void AttackHitEvent()
    {
        if (player != null)
        {
            Debug.Log("bang bang!");
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
