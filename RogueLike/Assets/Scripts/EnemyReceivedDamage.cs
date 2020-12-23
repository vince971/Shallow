using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceivedDamage : MonoBehaviour
{
    /// <summary>
    /// Enemy Health
    /// </summary>
    public float health;

    /// <summary>
    /// Enemy max health
    /// </summary>
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    /// <summary>
    /// Perform damage to the enemy.
    /// </summary>
    /// <param name="damage"></param>
    public void DealDamage(float damage)
    {
        health -= damage;
        this.CheckDeath();
    }

    /// <summary>
    /// Check the over heal
    /// </summary>
    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    /// <summary>
    /// Check if the enemy has enough life
    /// </summary>
    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
