using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public PlayerController playerScript;
    public Camera mainCamera;
    public Text hpText;
    
    private float hp;

    private void Start()
    {
        hpText = GetComponent<Text>();

        float verticalMin = -mainCamera.orthographicSize;
        float horizontalMin = -mainCamera.aspect * verticalMin;

        Vector2 healthPosition = new Vector2(horizontalMin, verticalMin);

        transform.position = healthPosition;
    }

    private void Update()
    {
        hp = playerScript.health;

        hpText.text = hp.ToString();
    }
}
