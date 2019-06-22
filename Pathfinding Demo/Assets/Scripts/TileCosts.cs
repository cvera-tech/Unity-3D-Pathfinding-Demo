using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TileCosts")]
public class TileCosts : SingletonScriptableObject<TileCosts>
{
    public Dictionary<Terrain, int> costs = new Dictionary<Terrain, int>
    {
        {Terrain.Flat, 1},
        {Terrain.Hill, 2},
        {Terrain.Forest, 2},
        {Terrain.HillForest, 3}
    };
    public int Cost(Terrain terrain) => costs[terrain];
}
