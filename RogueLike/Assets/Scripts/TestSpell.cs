using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    /// <summary>
    /// The Projectile object.
    /// </summary>
    public GameObject projectile;

    /// <summary>
    /// The minimum damage.
    /// </summary>
    public float minDamage;
  
    /// <summary>
    /// The maximum damage.
    /// </summary>
    public float maxDamage;

    /// <summary>
    /// The projectile force.
    /// </summary>
    public float projectileForce;

    /// <summary>
    /// Will run at each frame.
    /// </summary>
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;

        if (Input.GetMouseButtonDown(1))
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePosition - myPos).normalized;

            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<TestProjectile>().damage = Random.Range(minDamage, maxDamage);
        }
    }
}
