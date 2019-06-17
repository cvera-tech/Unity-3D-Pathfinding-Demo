using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private int x;
    private int z;
    private Terrain terrain;
    
    public static Node Create(in Map map, int x, int z, Terrain terrain = Terrain.Flat) 
    {
        Prefabs prefabs = Prefabs.Instance;
        GameObject tilePrefab;
        switch (terrain)
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
        GameObject newTile = Instantiate(tilePrefab, new Vector3(x, 0, z), Quaternion.identity, map.transform);  // Create the GameObject as a child of the Map GameObject
        Node n = newTile.AddComponent<Node>();  // Add and initialize the Node script to the GameObject
        n.X = x;
        n.Z = z;
        n.Terrain = terrain;
        newTile.name = n.ToString(); // Make sure each tile has a unique name
        newTile.AddComponent<HighlightScript>();
        return n;
    }
    
    // Properties
    public int X { get => x; set => x = value; }
    public int Z { get => z; set => z = value; }
    public Terrain Terrain { get => terrain; set => terrain = value; }

    public List<Node> AdjacentNodes(in Map map) 
    {
        List<Node> adjNodes = new List<Node>();

        // Check for nodes on the edges of the graph
        if (x > 0)
        {
            adjNodes.Add(map.NodeAt(x - 1, z));
        }
        if (x < map.MaxX - 1)
        {
            adjNodes.Add(map.NodeAt(x + 1, z));
        }
        if (z > 0)
        {
            adjNodes.Add(map.NodeAt(x, z - 1));
        }
        if (z < map.MaxZ - 1)
        {
            adjNodes.Add(map.NodeAt(x, z + 1));
        }
        return adjNodes;
    }

    public override string ToString() => "[" + x + ", " + z + "]";
}
