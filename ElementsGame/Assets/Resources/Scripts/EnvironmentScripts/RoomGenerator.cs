using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{

    private string roomType;
    private Vector3 location;

    private PlayerController playerScript;

    private void Start()
    {
        GameObject Player = GameObject.Find("Player");
        playerScript = Player.GetComponent<PlayerController>();

        if (playerScript.roomsGenerated <= 5)
        {
            location = new Vector3(transform.position.x, transform.position.y, 0);
            roomType = "Prefabs/LevelCreation/LevelPresets/LvlLayout" + 1f;

            GameObject instance = Instantiate(Resources.Load(roomType, typeof(GameObject)), location, Quaternion.identity) as GameObject;
            playerScript.roomsGenerated++;
            
            Destroy(gameObject);
        }
    }
}