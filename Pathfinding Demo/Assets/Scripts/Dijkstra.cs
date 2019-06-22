using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : Algorithm
{

    // Mark all nodes unvisited. Create a set of all the unvisited nodes called the unvisited set.
    // Assign to every node a tentative distance value: set it to zero for our initial node and to infinity for all other nodes. Set the initial node as current.
    // For the current node, consider all of its unvisited neighbours and calculate their tentative distances through the current node. Compare the newly calculated tentative distance to the current assigned value and assign the smaller one. For example, if the current node A is marked with a distance of 6, and the edge connecting it with a neighbour B has length 2, then the distance to B through A will be 6 + 2 = 8. If B was previously marked with a distance greater than 8 then change it to 8. Otherwise, keep the current value.
    // When we are done considering all of the unvisited neighbours of the current node, mark the current node as visited and remove it from the unvisited set. A visited node will never be checked again.
    // If the destination node has been marked visited (when planning a route between two specific nodes) or if the smallest tentative distance among the nodes in the unvisited set is infinity (when planning a complete traversal; occurs when there is no connection between the initial node and remaining unvisited nodes), then stop. The algorithm has finished.
    // Otherwise, select the unvisited node that is marked with the smallest tentative distance, set it as the new "current node", and go back to step 3.
    
    private class PathNode : IEquatable<PathNode>
    {
        private MapNode mapNode;    // The MapNode encapsulated by this object
        private MapNode previous;   // The previous MapNode (for recreating the path)
        private int distance;       // The total distance from the source node
        public PathNode(MapNode mapNode)
        {
            this.mapNode = mapNode;
            previous = null;   // [0,0] already exists in the graph
            distance = int.MaxValue;    // Mathf.Infinity is a float, so we can't use it. Be careful of overflow!
        }

        // Properties
        public MapNode MapNode { get => mapNode; set => mapNode = value; }
        public MapNode Previous { get => previous; set => previous = value; }
        public int Distance { get => distance; set => distance = value; }

        // Methods
        public bool Equals(PathNode other) => mapNode.Equals(other.mapNode);
        public override string ToString() => "MapNode: " + mapNode + "\nPrevious: " + previous + "\nDistance: " + distance;
        public int DistanceTo(PathNode other) => distance + TileCosts.Instance.Cost(other.MapNode.Terrain);
    }

    // Inherited from Algorithm:
    // public Map map;
    // public MapNode startNode;
    // public MapNode endNode;
    // public bool ready;
    // public bool running;
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
        ready = true;   // Algorithm ready to begin
    }

    public override void Step()
    {
        if (!ready) // Do not run the algorithm if it is not initialized or if it has finished
        {
            Debug.Log("Algorithm not ready.");
            return;
        }
        List<MapNode> adjMapNodes = map.AdjacentNodes(currentNode.MapNode); // Get adjacent MapNodes
        List<PathNode> adjPathNodes = new List<PathNode>(); 
        foreach (MapNode mn in adjMapNodes)
        {
            PathNode pn = unvisited.Find(node => mn.Equals(node.MapNode)); // Get corresponding PathNode in the unvisited set
            if (pn != null)
            {
                adjPathNodes.Add(pn);
                //Debug.Log(pn);  // Print initial PathNode values
            }
        }

        foreach (PathNode pn in adjPathNodes)
        {
            int newDistance = currentNode.DistanceTo(pn);
            if (newDistance < pn.Distance)
            {
                pn.Distance = newDistance;
                pn.Previous = currentNode.MapNode;
            }
            //Debug.Log(pn);  // Print updated PathNode values
        }

        if (currentNode.MapNode.Equals(endNode))    // Stop the algorithm once we have examined the end node.
        {
            ready = false;
            Debug.Log("Algorithm finished.");
            PathNode traceNode = currentNode;
            StringBuilder path = new StringBuilder();
            while (traceNode.MapNode != null)
            {
                path.Insert(0, traceNode.MapNode + "\tDistance: " + traceNode.Distance + "\n");    // Add node to the path in the correct order
                map.TileAt(traceNode.MapNode).GetComponent<HighlightScript>().Highlight();  // Highlight the tiles in the path
                if (traceNode.Previous != null)
                    traceNode = visited.Find(pn => traceNode.Previous.Equals(pn.MapNode));  // Go to the previous node in the path
                else
                    traceNode.MapNode = null;
            }

            Debug.LogFormat(path.ToString());   // Print out the path
        }
        visited.Add(currentNode);
        unvisited.Remove(currentNode);
        currentNode = NextPathNode();
        if (currentNode == null)
        {
            ready = false;
            Debug.Log("No more unvisited nodes.");
        }
        //Debug.Log(currentNode); // Print the next node to examine
    }

    // Currently O(N). Perhaps this can be improved to O(1) if the next node is determined during the distance calculation in the Step() method.
    private PathNode NextPathNode()
    {
        int minimum = int.MaxValue;
        PathNode nextPathNode = default;
        // Debug.Log(nextPathNode);
        foreach (PathNode pn in unvisited)
        {
            if (pn.Distance < minimum)
            {
                minimum = pn.Distance;
                nextPathNode = pn;
            }
        }
        return nextPathNode;
    }

    // Temporary driver
    public void Run()
    {
        while (ready)
        {
            Step();
        }
    }
}
