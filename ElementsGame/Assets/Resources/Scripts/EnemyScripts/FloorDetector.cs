using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetector : MonoBehaviour
{

    private bool touching;
    public bool platformEnds;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            platformEnds = false;
        }
    }

    private void FixedUpdate()
    {
        platformEnds = true;
    }

}
