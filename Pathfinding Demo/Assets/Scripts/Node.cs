using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

public class Node
{
    private int x;
    private int y;
    //public enum terrainTag : byte {Flat, Hill, Forest, HillForest};

    public Node (int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public List<Node> AdjacentNodes(in Map map) 
    {
        List<Node> adjNodes = new List<Node>();

        // Check for nodes on the edges of the graph
        if (this.x != 0)
        {
            adjNodes.Add(map.Graph[this.x - 1, this.y]);
        }
        if (this.x != map.MaxX)
        {
            adjNodes.Add(map.Graph[this.x + 1, this.y]);
        }
        if (this.y != 0)
        {
            adjNodes.Add(map.Graph[this.x, this.y - 1]);
        }
        if (this.y != map.MaxY)
        {
            adjNodes.Add(map.Graph[this.x, this.y + 1]);
        }
        return adjNodes;
    }

    public override string ToString() 
    {
        return "[" + this.x + ", " + this.y + "]";
    }
}
