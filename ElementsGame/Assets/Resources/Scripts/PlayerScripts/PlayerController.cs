using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Transform groundCheck;
    public float sphereRadius;
    public LayerMask groundMask;
    public float jumpHeight;

    public int maxHealth;
    public int health;

    public float roomsGenerated;

    private Rigidbody2D playerRigidBody;
    private bool airJumpLeft;
    private bool inAir;
    private bool downKeyHeldDown;
    private float timer;

    public HealthBar healthBar;

    [SerializeField]
    private PlayerShooting firingScript;

    [SerializeField]
    private GameObject spriteRenderer;

    [SerializeField]
    private Collider2D hitbox;

    [SerializeField]
    private ParticleSystem damageEffect;

    public void Awake()
    {
        roomsGenerated = 0;
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void FixedUpdate()
    {
        Movement();

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timer = 0;
            hitbox.enabled = true;
        }
    }

    void Update()
    {
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

        if (health <= 0)
        {
            Debug.Log("RIP");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }


    void Movement()
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

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !downKeyHeldDown)
        {
            Vector2 yMovement = new Vector2(playerRigidBody.velocity.x, jumpHeight);
            playerRigidBody.AddForce(yMovement, ForceMode2D.Impulse);

            airJumpLeft = false;
        }
    }

    void AirJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 yMovement = new Vector2(playerRigidBody.velocity.x, jumpHeight);
            playerRigidBody.velocity = yMovement;
            airJumpLeft = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyAttacks")
        {
            damageEffect.Play();
            TakeDamage(5);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            damageEffect.Play();
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WoodenPlatform")
        {
            if (Input.GetKey(KeyCode.S))
            {
                downKeyHeldDown = true;
                if (Input.GetKey(KeyCode.Space)) 
                {
                    hitbox.enabled = false;
                    timer = 0.3f;
                }

            }
            else
            {
                downKeyHeldDown = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedCrystal")
        {
            if (Input.GetKey(KeyCode.E))
            {
                firingScript.ActiveElement = 0;
            }
        }
        if (collision.gameObject.tag == "BlueCrystal")
        {
            if (Input.GetKey(KeyCode.E))
            {
                firingScript.ActiveElement = 1;
            }
        }
    }


}