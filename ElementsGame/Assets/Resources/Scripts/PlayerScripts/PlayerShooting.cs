using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject projectile;
    public GameObject heavyProjectile;

    private float timer;
    private float heavyTimer;
    private Vector3 mousePos;
    public string ActiveElement;
    private bool fireCooldown;
    private bool heavyFireCooldown;

    [SerializeField]
    LayerMask hitMask;

    private void Start()
    {
        ActiveElement = "Fire";
    }

    private void Update()
    {

        LookAtMouse();

        if (Input.GetButton("Fire1"))
        {
            Shooting();
        }
        if (Input.GetButton("Fire2"))
        {
            HeavyShooting();
        }
    }

    private void FixedUpdate()
    {
        if (fireCooldown || heavyFireCooldown)
        {
            FiringTimer();
        }
    }

    private void LookAtMouse()
    {
        mousePos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 100, hitMask))
        {
            Vector3 dir = hit.point - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void Shooting()
    {
        Vector3 projectilePosition = transform.position;
        projectilePosition.z = 0.1f;

        if (!fireCooldown)
        {
            timer = 1f;
            fireCooldown = true;
            Instantiate(projectile, projectilePosition, transform.rotation);
        }
    }

    private void HeavyShooting()
    {
        Vector3 projectilePosition = transform.position;
        projectilePosition.z = 0.1f;

        if (!heavyFireCooldown)
        {
            heavyTimer = 5f;
            heavyFireCooldown = true;
            Instantiate(heavyProjectile, projectilePosition, transform.rotation);
        }
    }

    private void FiringTimer()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timer = 0;
            fireCooldown = false;
        }

        if (heavyTimer > 0)
        {
            heavyTimer -= Time.deltaTime;
        }
        if (heavyTimer <= 0)
        {
            heavyTimer = 0;
            heavyFireCooldown = false;
        }

    
    }


}
