using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform groundCheck;
    public float sphereRadius;
    public LayerMask groundMask;
    public float jumpHeight;

    public float roomsGenerated;

    private Rigidbody2D playerRigidBody;

    public void Awake()
    {
        roomsGenerated = 0;
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, sphereRadius, groundMask) == null)
        {
            return;
        }
        else
        {
            Jump();
        }
    }


    void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        Vector2 xMovement = new Vector2(xInput * moveSpeed, playerRigidBody.velocity.y);
        playerRigidBody.velocity = xMovement;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 yMovement = new Vector2(playerRigidBody.velocity.x, jumpHeight);
            playerRigidBody.AddForce(yMovement, ForceMode2D.Impulse);
            
        }
    }



}
