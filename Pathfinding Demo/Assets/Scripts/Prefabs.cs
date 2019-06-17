using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prefabs")]
public class Prefabs : SingletonScriptableObject<Prefabs>
{
    public GameObject flatTile;
    public GameObject hillTile;
}
