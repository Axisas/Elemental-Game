using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed;

    public Rigidbody2D rb;

    private float bulletTimer;

    [SerializeField]
    private ParticleSystem explosion;

    [SerializeField]
    private ParticleSystem trail;

    [SerializeField]
    private SpriteRenderer sprite;
    
    [SerializeField]
    private Collider2D c;

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
            explosion.Play();
            trail.Stop();
            c.enabled = false;
            sprite.enabled = false;
            rb.velocity = Vector2.zero;
            Destroy(gameObject, 0.5f);
        }
        if (other.gameObject.tag == "Enemy")
        {
            explosion.Play();
            trail.Stop();
            c.enabled = false;
            sprite.enabled = false;
            rb.velocity = Vector2.zero;
            Destroy(gameObject, 0.5f);
        }
    }

}
