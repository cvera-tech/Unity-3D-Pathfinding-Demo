using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private const int defaultMaxX = 10;
    private const int defaultMaxZ = 10;

    private int maxX;
    private int maxZ;

    private List<Node> graph;
    private Prefabs prefabs;

    public Map() 
    {
        prefabs = Prefabs.Instance; // Get the asset that contains all the prefabs
        maxX = defaultMaxX;
        maxZ = defaultMaxZ;
        graph = new List<Node>(maxX * maxZ);
        int count = 0;
        for (int i = 0; i < maxX; i++, count++)
        {
            for (int j = 0; j < maxZ; j++, count++)
            {
                if (count % 2 == 0)
                    graph.Add(new Node(i, j));
                else
                    graph.Add(new Node(i, j, Terrain.Hill));
            }
        }
    }

    public int MaxX { get => maxX; set => this.maxX = value; }

    public int MaxZ { get => maxZ; set => this.maxZ = value; }

    public List<Node> Graph { get => graph; }

    public Node NodeAt(int x, int z) => graph[z * maxZ + x];

    public void PrintGraph()
    {
        foreach (Node n in graph) 
        {
            Debug.Log(n);
        }
    }

    public void CreateMapTiles() 
    {
        foreach (Node n in graph)
        {
            GameObject tilePrefab;
            switch (n.Terrain)
            {
                case Terrain.Flat:
                    tilePrefab = prefabs.flatTile;
                    break;
                case Terrain.Hill:
                    tilePrefab = prefabs.hillTile;
                    break;
                default:
                    tilePrefab = prefabs.flatTile;
                    break;
            }
            n.Tile = Object.Instantiate(tilePrefab, new Vector3(n.X, 0, n.Z), Quaternion.identity);
        }
    }

    
}
