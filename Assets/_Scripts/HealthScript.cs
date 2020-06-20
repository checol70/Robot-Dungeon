using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    int maxHealth, currentHealth;
    public void SetMaxHealth(int max)
    {
        maxHealth = max;
        currentHealth = maxHealth;
    }
    public void Damaged(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
