using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Map testMap;
    private bool toggle = false;

    // Start is called before the first frame update
    void Start()
    {
        testMap = gameObject.AddComponent<Map>();
        testMap.Initialize();
        testMap.CreateMapTiles();

        Dijkstra d = new Dijkstra(testMap, testMap.Graph[0], testMap.NodeAt(5, 8));
        d.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !toggle)
        {
            toggle = true;
            List<MapNode> newNodes = new List<MapNode>()
            {
                new MapNode(0, 0, Terrain.Flat),
                new MapNode(0, 1, Terrain.Hill),
                new MapNode(1, 0, Terrain.Hill),
                new MapNode(1, 1, Terrain.Flat)
            };
            testMap.Initialize(2, 2, newNodes);
            testMap.CreateMapTiles();
        }
    }
}
