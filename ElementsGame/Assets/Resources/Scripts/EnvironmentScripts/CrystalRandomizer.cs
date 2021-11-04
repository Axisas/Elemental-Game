using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalRandomizer : MonoBehaviour
{

    public GameObject redCrystal;
    public GameObject blueCrystal;

    private void Awake()
    {
        float randomCrystal = Random.Range(0, 2);
        if (randomCrystal == 0)
        {
            redCrystal.SetActive(true);
        }
        if (randomCrystal == 1)
        {
            blueCrystal.SetActive(true);
        }

    }

}
