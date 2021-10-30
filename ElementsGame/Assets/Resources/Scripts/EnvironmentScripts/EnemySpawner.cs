using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;

    private void Awake()
    { 
        float random = Random.Range(0,5);
        if (random <= 1)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
