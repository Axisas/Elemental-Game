using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private float moveSpeed;
    private float xScale;

    public float health;

    [SerializeField]
    private FloorDetector floorDetector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 3;
        xScale = 1;
        health = 5;
    }

    private void Update()
    {
        Movement();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Movement()
    {
        if (!floorDetector.platformEnds)
        {
            rb.velocity = new Vector3(moveSpeed, 0, 0);
        } else
        {
            Rotate();
        }

        if (!transform.hasChanged)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        xScale = -xScale;
        moveSpeed = -moveSpeed;
        transform.localScale = new Vector3(xScale, 1, 1);
        floorDetector.platformEnds = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
            health--;
        }
    }
}
