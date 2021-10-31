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
            float lvlRandom = Random.Range(1,3);
            location = new Vector3(transform.position.x, transform.position.y, 0);
            roomType = "Prefabs/LevelCreation/LevelPresets/LvlLayout" + lvlRandom;

            GameObject instance = Instantiate(Resources.Load(roomType, typeof(GameObject)), location, Quaternion.identity) as GameObject;
            playerScript.roomsGenerated++;
            
            Destroy(gameObject);
        }
    }
}