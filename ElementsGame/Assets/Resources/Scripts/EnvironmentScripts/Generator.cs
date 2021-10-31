using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Generator : MonoBehaviour
{
    
    BoxCollider2D boxCollider;
    Vector2 Size;
    private string presetType;
    private float randomizer;
    Vector3 location;

    private void Awake()
    {

        location = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        boxCollider = GetComponent<BoxCollider2D>();
        
        Size = boxCollider.size * 10;

        randomizer = Random.Range(0, 4);
        string areaType = Size.x + "x" + Size.y;
        presetType = "Prefabs/LevelCreation/PlatformPresets/" + areaType + "/" + Size.x + "x" + Size.y + "." + randomizer;

        GameObject instance = Instantiate(Resources.Load(presetType, typeof(GameObject)), location, Quaternion.identity) as GameObject;

        Destroy(gameObject);
    }


}
