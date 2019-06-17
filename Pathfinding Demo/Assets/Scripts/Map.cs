using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MapNode
{
    public int x;
    public int z;
    public Terrain terrain;
    public MapNode(int x, int z, Terrain terrain)
    {
        this.x = x;
        this.z = z;
        this.terrain = terrain;
    }
    public override string ToString() => "[" + x + ", " + z + "] " + terrain;
}

public class InvalidMapParametersException : System.Exception
{
    public InvalidMapParametersException(int x, int z, int size) : base(x + " * " + z + "!="){}
}

public class Map : MonoBehaviour
{
    private int maxX = 10;  // Default map size is 10*10
    private int maxZ = 10;
    public List<MapNode> graph;
    
    public void Initialize()
    {
        MaxX = 10;
        MaxZ = 10;
        Graph = new List<MapNode>();
        for (int i = 0; i < MaxX; i++)
        {
            for (int j = 0; j < MaxZ; j++)
            {
                Graph.Add(new MapNode(i, j, Terrain.Flat));
            }
        }
    }

    public void Initialize(int maxX, int maxZ, List<MapNode> graph)
    {
        // Throw exception for invalid arguments for now
        if (maxX * maxZ != graph.Count)
            throw new System.ArgumentException("maxX * maxZ != graph.Count");
            
        MaxX = maxX;
        MaxZ = maxZ;
        if (Graph != null && transform.childCount > 0)  // Destroy child tiles if they exist
            DestroyTiles();
        Graph = graph;
    }

    // Properties
    public int MaxX { get => maxX; set => maxX = value; }
    public int MaxZ { get => maxZ; set => maxZ = value; }
    public List<MapNode> Graph { get => graph; set => graph = value; }
    
    public MapNode NodeAt(int x, int z) => graph[x * maxZ + z];

    public Tile TileAt(MapNode mn) => transform.Find(mn.ToString()).GetComponent<Tile>();

    public void PrintGraph()
    {
        foreach (MapNode n in graph) 
        {
            Debug.Log(n);
        }
    }

    public void CreateMapTiles() 
    {
        Prefabs prefabs = Prefabs.Instance;
        GameObject tilePrefab;
        foreach (MapNode mn in graph)
        {
            switch (mn.terrain)
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
            GameObject newTile = Instantiate(tilePrefab, new Vector3(mn.x, 0, mn.z), Quaternion.identity, transform);  // Create the GameObject as a child of the Map GameObject
            newTile.name = mn.ToString(); // Make sure each tile has a unique name
            Tile tile = newTile.AddComponent<Tile>(); // Store the MapNode info in the GameObject
            tile.nodeInfo = mn;
            newTile.AddComponent<HighlightScript>();
        }
    }

    public void DestroyTiles()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public List<MapNode> AdjacentNodes(MapNode mn)
    {
        int x = mn.x;
        int z = mn.z;

        List<MapNode> adjNodes = new List<MapNode>();

        // Check for nodes on the edges of the graph
        if (x > 0)
        {
            adjNodes.Add(NodeAt(x - 1, z));
        }
        if (x < MaxX - 1)
        {
            adjNodes.Add(NodeAt(x + 1, z));
        }
        if (z > 0)
        {
            adjNodes.Add(NodeAt(x, z - 1));
        }
        if (z < MaxZ - 1)
        {
            adjNodes.Add(NodeAt(x, z + 1));
        }
        return adjNodes;
    }
}