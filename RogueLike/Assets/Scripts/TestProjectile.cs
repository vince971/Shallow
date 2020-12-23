using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    /// <summary>
    /// The damage of the projectile
    /// </summary>
    public float damage;

    /// <summary>
    /// When the projectile touch something.
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            var enemyScript = collision.GetComponent<EnemyReceivedDamage>();
            if (enemyScript != null)
            {
                enemyScript.DealDamage(damage);
            }

            this.DestroyObject(gameObject);
        }
    }

    /// <summary>
    /// Destroy the game object
    /// </summary>
    /// <param name="gameObj"></param>
    private void DestroyObject(GameObject gameObj)
    {
        Destroy(gameObj);
    }
}
