using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Algorithm
{
    public Map map;
    public MapNode startNode;
    public MapNode endNode;
    public bool ready = false;
    public bool running = false;

    //public abstract void Initialize(Map map, MapNode startNode, MapNode endNode);
    public abstract void Step();
}
