using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceCloser : MonoBehaviour
{

    public bool playerHasEntered;
    [SerializeField] private BoxCollider2D wall;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.layer == 6)
        {
            playerHasEntered = true;
        }
        
    }

    private void Update()
    {
        if (playerHasEntered)
        {
            wall.enabled = true;
        }
    }

}
