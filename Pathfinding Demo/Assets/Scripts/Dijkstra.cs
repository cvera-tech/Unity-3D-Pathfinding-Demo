using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : Algorithm
{

    // Mark all nodes unvisited. Create a set of all the unvisited nodes called the unvisited set.
    // Assign to every node a tentative distance value: set it to zero for our initial node and to infinity for all other nodes. Set the initial node as current.[13]
    // For the current node, consider all of its unvisited neighbours and calculate their tentative distances through the current node. Compare the newly calculated tentative distance to the current assigned value and assign the smaller one. For example, if the current node A is marked with a distance of 6, and the edge connecting it with a neighbour B has length 2, then the distance to B through A will be 6 + 2 = 8. If B was previously marked with a distance greater than 8 then change it to 8. Otherwise, keep the current value.
    // When we are done considering all of the unvisited neighbours of the current node, mark the current node as visited and remove it from the unvisited set. A visited node will never be checked again.
    // If the destination node has been marked visited (when planning a route between two specific nodes) or if the smallest tentative distance among the nodes in the unvisited set is infinity (when planning a complete traversal; occurs when there is no connection between the initial node and remaining unvisited nodes), then stop. The algorithm has finished.
    // Otherwise, select the unvisited node that is marked with the smallest tentative distance, set it as the new "current node", and go back to step 3.
    
    private class PathNode : IEquatable<PathNode>
    {
        private MapNode mapNode;
        private MapNode previous;
        private int distance;
        public PathNode(MapNode mapNode)
        {
            this.mapNode = mapNode;
            previous = new MapNode(-1, -1, Terrain.Flat);   // [0,0] already exists in the graph
            distance = int.MaxValue;    // Risky. Don't do math with this!
        }
        public MapNode MapNode { get => mapNode; set => mapNode = value; }
        public MapNode Previous { get => previous; set => previous = value; }
        public int Distance { get => distance; set => distance = value; }

        public bool Equals(PathNode other) => mapNode.Equals(other.mapNode);
        public override string ToString() => mapNode + "\t" + previous + "\t" + distance;
    }

    List<PathNode> visited;
    List<PathNode> unvisited;
    PathNode currentNode;

    public Dijkstra(Map map, MapNode startNode, MapNode endNode)
    {
        this.map = map;
        this.startNode = startNode;
        this.endNode = endNode;
        visited = new List<PathNode>();
        unvisited = new List<PathNode>();
        foreach (MapNode mn in map.Graph)   // Create a PathNode for every MapNode
        {
            PathNode pn = new PathNode(mn); // Distance of new PathNode objects is set to max int value
            if (mn.Equals(startNode))
            {
                currentNode = pn;
                pn.Distance = 0;    // Set start node distance to 0
            }
            unvisited.Add(pn);
        }
    }

    public override void Step()
    {
        throw new System.NotImplementedException();
    }
}
