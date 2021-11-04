using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePlatform : MonoBehaviour
{
    public float bulletSpeed;

    public Rigidbody2D rb;

    private float timer;
    private float platformTimer;

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
        rb.velocity = transform.right * bulletSpeed;
        c.enabled = false;
        timer = 0.28f;
        platformTimer = 5;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timer = 0;
            c.enabled = true;
        }

        Timer();
    }

    private void Timer()
    {
        if (platformTimer > 0)
        {
            platformTimer -= Time.deltaTime;
        }
        if (platformTimer <= 0)
        {
            platformTimer = 0;
            explosion.Play();
            c.enabled = false;
            sprite.enabled = false;
            trail.Stop();
            Destroy(gameObject, 1);
        }
    }
}
