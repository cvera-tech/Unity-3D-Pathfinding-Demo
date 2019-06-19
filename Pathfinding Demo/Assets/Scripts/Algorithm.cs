using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Algorithm
{
    public Map map;
    public MapNode startNode;
    public MapNode endNode;
    public abstract void Step();
}
