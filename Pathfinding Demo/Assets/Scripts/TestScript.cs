using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Map testMap;
    // Start is called before the first frame update
    void Start()
    {
        testMap = new Map();
        testMap.CreateMapTiles();
        //testMap.PrintGraph();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Destroy(testMap.Graph[0].Tile);
            Debug.Log(testMap.Graph[0]);
            testMap.Graph.RemoveAt(0);
        }
    }
}
