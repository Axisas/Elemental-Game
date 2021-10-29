using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;

    private Vector3 offset = new Vector3(0, 1, -5f);
    private Vector3 location = new Vector3();

    private void LateUpdate()
    {
        if (player != null)
        {
            location = player.position + offset;
            location.x = Mathf.Max(location.x, 9);
            location.y = Mathf.Clamp(location.y, -0.8f, 15);
            transform.position = location;
        }
    }

}
