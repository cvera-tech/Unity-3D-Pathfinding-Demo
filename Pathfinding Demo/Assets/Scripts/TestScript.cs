using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Map testMap;

    // Start is called before the first frame update
    void Start()
    {
        testMap = gameObject.AddComponent<Map>();    // Create a default map (10*10 flat tiles)
        testMap.CreateMapTiles();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
