using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int health;


    private void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(int damageAmout)
    {
        if (health <= 0)
        {
            return;
        }

        health = Mathf.Max(health - damageAmout, 0); //reducing health by amount and making sure it doesn't drop below zero

        Debug.Log(health);
    }

}
