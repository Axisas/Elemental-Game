using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject projectile;

    private float timer;
    private Vector3 mousePos;
    public string ActiveElement;
    private bool fireCooldown;

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
    }

    private void FixedUpdate()
    {
        if (fireCooldown)
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

    private void FiringTimer()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            fireCooldown = false;
        }

    }


}
