using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePlatform : MonoBehaviour
{
    public float bulletSpeed;

    public Rigidbody2D rb;

    private float bulletTimer;
    private float platformTimer;

    [SerializeField]
    private ParticleSystem explosion;

    [SerializeField]
    private ParticleSystem trail;

    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private Collider2D triggerCollider;

    [SerializeField]
    private Collider2D platformCollider;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            platformCollider.enabled = true;
            sprite.enabled = true;
            platformTimer = 3;
        }

    }

    private void Update()
    {
        if (platformTimer > 0)
        {
            platformTimer -= Time.deltaTime;
        }
        if (platformTimer <= 0)
        {
            platformTimer = 0;
            Destroy(gameObject);
        }
    }
}
