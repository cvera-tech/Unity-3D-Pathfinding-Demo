using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private const int defaultMaxX = 10;
    private const int defaultMaxZ = 10;

    private int maxX;
    private int maxZ;

    public List<Node> graph;
    private Prefabs prefabs;

    public void Start() 
    {
        prefabs = Prefabs.Instance; // Get the asset that contains all the prefabs
        maxX = defaultMaxX;
        maxZ = defaultMaxZ;
        graph = new List<Node>(maxX * maxZ);
        CreateMapTiles();
    }

    // Properties
    public int MaxX { get => maxX; set => this.maxX = value; }
    public int MaxZ { get => maxZ; set => this.maxZ = value; }
    public List<Node> Graph { get => graph; }
    public Node NodeAt(int x, int z) 
    {
        return graph[x * maxZ + z];
    }

    public void PrintGraph()
    {
        foreach (Node n in graph) 
        {
            Debug.Log(n);
        }
    }

    public void CreateMapTiles() 
    {
        int count = 0;
        for (int i = 0; i < maxX; i++, count++)
        {
            for (int j = 0; j < maxZ; j++, count++)
            {
                // if (count % 2 == 0)
                    graph.Add(Node.Create(this, i, j));
                // else
                //     graph.Add(Node.Create(this, i, j, Terrain.Hill));
            }
        }
    }
}
