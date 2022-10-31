using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int health;
    private bool isInvulnerable;

    public event Action OnTakeDamage;
    public event Action OnDie;

    public bool IsDead => health == 0;


    private void Start()
    {
        health = maxHealth;
    }

    public void SetInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;
    }

    public void DealDamage(int damageAmout)
    {
        if (health == 0)
        {
            return;
        }

        if(isInvulnerable) { return; }

        health = Mathf.Max(health - damageAmout, 0); //reducing health by amount and making sure it doesn't drop below zero

        OnTakeDamage?.Invoke();

        if(health == 0)
        {
            OnDie?.Invoke();
        }

        Debug.Log(health);
    }

}
