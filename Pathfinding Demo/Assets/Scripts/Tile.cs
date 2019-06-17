using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public MapNode nodeInfo;
    public override string ToString() => nodeInfo.ToString();
}
