using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private const int defaultMaxX = 10;
    private const int defaultMaxY = 10;

    private int maxX;
    private int maxY;

    private Node[,] graph;

    public Map() 
    {
        maxX = defaultMaxX;
        maxY = defaultMaxY;
        graph = new Node[maxX, maxY];
        for (int i = 0; i < maxX; i++) 
        {
            for (int j = 0; j < maxY; j++)
            {
                graph[i, j] = new Node(i, j);
            }
        }
    }

    public int MaxX { get => maxX; set => this.maxX = value; }

    public int MaxY { get => maxY; set => this.maxY = value; }

    public Node[,] Graph { get => graph; }

    public void PrintGraph()
    {
        foreach (Node n in graph) 
        {
            Debug.Log(n);
        }
    }
}
