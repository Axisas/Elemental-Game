using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed;

    public Rigidbody2D rb;

    private float bulletTimer;

    void Start()
    {
        bulletTimer = 3;
        rb.velocity = transform.right * bulletSpeed;
        if (bulletTimer > 0)
        {
            bulletTimer -= Time.deltaTime;
        }
        if (bulletTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }

}
