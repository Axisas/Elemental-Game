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
    int hitMask;

    private void Start()
    {
        ActiveElement = "Fire";
    }

    private void Update()
    {

        LookAtMouse();

        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }

        Debug.Log(fireCooldown);
        Debug.Log(timer);
    }

    private void LookAtMouse()
    {
        mousePos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position + ray.direction * 100, Color.red);

        if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 100, 1 << hitMask))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);

            Vector3 dir = hit.point - transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void Shooting()
    {
        Vector3 projectilePosition = new Vector3(transform.position.x, transform.position.y, 0.1f);
       
        if (!fireCooldown)
        {
            timer = 3f;
            Instantiate(projectile, projectilePosition, transform.rotation);
            FiringTimer();
        }
    }

    private void FiringTimer()
    {
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            fireCooldown = true;
        }
        if (timer <= 0)
        {
            fireCooldown = false;
        }

    }


}
