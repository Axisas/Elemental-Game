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
    private float attackTimer;

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

    [SerializeField]
    private SpriteRenderer swipeSprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveSpeed = 3;
        xScale = 1;
        health = 5;
        lookDistance = 8;
        direction = Vector2.right;
    }

    private void Update()
    {

        Movement();
        LookForPlayer();

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        
        // Timers
        if (attackTimer < 0.98f)
        {
            attackCollider.enabled = false;
            swipeSprite.enabled = false;
        }
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer <= 0)
        {
            attackTimer = 0;
        }
        
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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            health--;
        }
    }

    private void LookForPlayer()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(eyePoint.transform.position, direction, lookDistance, playerLayerMask);

        if (hitPlayer.collider != null)
        {
            RaycastHit2D hit = Physics2D.Linecast(eyePoint.transform.position, hitPlayer.transform.position, playerLayerMask);

            if (hit.distance < 3)
            {
                if (attackTimer <= 0)
                {
                    Invoke("Attack", 0.1f);
                }
            }
        }

    }

    private void Attack()
    {
        attackCollider.enabled = true;
        swipeSprite.enabled = true;

        attackTimer = 1;

    }
}
