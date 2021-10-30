using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public PlayerController playerScript;
    public Text hpText;
    
    private float hp;

    private void Start()
    {
        hpText = GetComponent<Text>();
    }

    private void Update()
    {
        hp = playerScript.Health;

        hpText.text = hp.ToString();
    }
}
