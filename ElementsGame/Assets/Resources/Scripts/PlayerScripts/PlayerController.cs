using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Transform groundCheck;
    public float sphereRadius;
    public LayerMask groundMask;
    public float jumpHeight;

    public float Health;

    public float roomsGenerated;

    private Rigidbody2D playerRigidBody;
    private bool airJumpLeft;
    private bool inAir;

    [SerializeField]
    private GameObject spriteRenderer;

    public void Awake()
    {
        roomsGenerated = 0;
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Health = 10;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("R.I.P. You died.");
        }

        if (Physics2D.OverlapCircle(groundCheck.position, sphereRadius, groundMask) == null)
        {
            inAir = true;
        }
        else
        {
            inAir = false;
            airJumpLeft = true;
        }

        if (!inAir)
        {
            Jump();
        }
        if (inAir && airJumpLeft)
        {
            AirJump();
        }
    }


    private void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        Vector2 xMovement = new Vector2(xInput * moveSpeed, playerRigidBody.velocity.y);
        playerRigidBody.velocity = xMovement;

        if (xInput < 0)
        {
            spriteRenderer.transform.localScale = new Vector3(-1, 1, 1);
        } 
        if (xInput > 0)
        {
            spriteRenderer.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 yMovement = new Vector2(playerRigidBody.velocity.x, jumpHeight);
            playerRigidBody.AddForce(yMovement, ForceMode2D.Impulse);
            
            airJumpLeft = false;
        }
    }

    private void AirJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 yMovement = new Vector2(playerRigidBody.velocity.x, jumpHeight);
            playerRigidBody.velocity = yMovement;
            airJumpLeft = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Health--;
        }
        if (collision.gameObject.tag == "EnemyAttacks")
        {
            Health -= 2;
        }
    }



}
