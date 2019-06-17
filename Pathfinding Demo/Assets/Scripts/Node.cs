using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private int x;
    private int z;
    private Terrain terrain;
    private GameObject tile;    // The GameObject that represents this node in the scene
    
    public Node (int x, int z)
    {
        this.x = x;
        this.z = z;
        this.terrain = Terrain.Flat;
    }

    public Node (int x, int z, Terrain terrain)
    {
        this.x = x;
        this.z = z;
        this.terrain = terrain;
    }
    
    // Properties
    public int X { get => x; }
    public int Z { get => z; }
    public Terrain Terrain { get => terrain; set => terrain = value; }
    public GameObject Tile { get => tile; set => tile = value; }

    public List<Node> AdjacentNodes(in Map map) 
    {
        List<Node> adjNodes = new List<Node>();

        // Check for nodes on the edges of the graph
        if (this.x != 0)
        {
            adjNodes.Add(map.NodeAt(this.x - 1, this.z));
        }
        if (this.x != map.MaxX)
        {
            adjNodes.Add(map.NodeAt(this.x + 1, this.z));
        }
        if (this.z != 0)
        {
            adjNodes.Add(map.NodeAt(this.x, this.z - 1));
        }
        if (this.z != map.MaxZ)
        {
            adjNodes.Add(map.NodeAt(this.x, this.z + 1));
        }
        return adjNodes;
    }

    public override string ToString() => "[" + this.x + ", " + this.z + "]";
}
