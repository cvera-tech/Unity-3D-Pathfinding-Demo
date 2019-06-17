using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : MonoBehaviour
{
    public GameObject MapObject;
    private List<Node> graph;
    // Start is called before the first frame update
    void Start()
    {
        graph = MapObject.GetComponent<Map>().Graph;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
