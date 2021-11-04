using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject fireProjectile;
    public GameObject fireHeavyProjectile;
    public GameObject iceProjectile;
    public GameObject iceHeavyProjectile;

    private GameObject activeProjectile;
    private GameObject activeHeavyProjectile;

    public HeavyCDBar cooldownBar;

    private float timer;
    private float heavyTimer;
    private float cooldownTimer;
    private Vector3 mousePos;
    public float ActiveElement;
    private bool fireCooldown;
    private bool heavyFireCooldown;

    [SerializeField]
    LayerMask hitMask;

    private void Start()
    {
        cooldownTimer = 10;
        int Timer = (int)cooldownTimer;
        cooldownBar.SetMaxValue(Timer);
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

        if (ActiveElement == 0)
        {
            activeProjectile = fireProjectile;
            activeHeavyProjectile = fireHeavyProjectile;
            return;
        } 
        if (ActiveElement == 1)
        {
            activeProjectile = iceProjectile;
            activeHeavyProjectile = iceHeavyProjectile;
        }
    }

    private void FixedUpdate()
    {
        if (fireCooldown || heavyFireCooldown)
        {
            FiringTimer();
        }

        cooldownBar.SetValue(cooldownTimer);
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
            Instantiate(activeProjectile, projectilePosition, transform.rotation);
        }
    }

    private void HeavyShooting()
    {
        Vector3 projectilePosition = transform.position;
        projectilePosition.z = 0.1f;

        if (!heavyFireCooldown)
        {
            heavyTimer = 10;
            cooldownTimer = 0;
            heavyFireCooldown = true;
            if (ActiveElement == 1)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                Instantiate(activeHeavyProjectile, projectilePosition, rotation);
            } else
            {
                Instantiate(activeHeavyProjectile, projectilePosition, transform.rotation);
            }
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
            cooldownTimer += Time.deltaTime;

        }
        if (heavyTimer <= 0)
        {
            heavyTimer = 0;
            heavyFireCooldown = false;
        }

    
    }


}
