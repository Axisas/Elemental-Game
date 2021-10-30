using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private float moveSpeed;
    private float xScale;
    private float lookDistance;
    private Vector2 direction;
    private Vector3 movement;

    public float health;

    [SerializeField]
    private FloorDetector floorDetector;

    [SerializeField]
    private WallDetector wallDetector;

    [SerializeField]
    private GameObject eyePoint;

    [SerializeField]
    private LayerMask playerLayerMask;

    [SerializeField]
    private Collider2D attackCollider;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveSpeed = 3;
        xScale = 1;
        health = 5;
        lookDistance = 5;
        direction = Vector2.right;
    }

    private void Update()
    {

        Movement();

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        LookForPlayer();

    }


    private void Movement()
    {
        movement = new Vector2(moveSpeed, rb.velocity.y);

        if (wallDetector.wallDetected)
        {
            Rotate();
        }
        if (!floorDetector.platformEnds)
        {
            rb.velocity = movement;
        }
        else
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        moveSpeed = -moveSpeed;
        direction = -direction;
        xScale = -xScale;
        transform.localScale = new Vector3(xScale, 1, 1);
        wallDetector.wallDetected = false;
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

    private void LookForPlayer()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(eyePoint.transform.position, direction, lookDistance, playerLayerMask);
        if (hitPlayer.collider != null)
        {
            Attack();
        }

    }

    private void Attack()
    { 
        /*
        float attackTimer = 2;
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            attackCollider.enabled = false;

        }
        if (attackTimer <= 0)
        {
            attackTimer = 0;
            attackCollider.enabled = true;
        }
        */
    }
}
