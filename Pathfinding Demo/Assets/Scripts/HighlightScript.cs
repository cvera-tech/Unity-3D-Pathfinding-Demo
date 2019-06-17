using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Adapted from Jimmy Vegas's video "Mini Unity Tutorial - How To Select And Highlight Objects In Game Realtime With C#"
 * https://www.youtube.com/watch?v=7ybz28Py0-U
 *
 */
public class HighlightScript : MonoBehaviour
{
    private Material tileMaterial;

    void Start()
    {
        tileMaterial = GetComponent<Renderer>().material;
        //map = GetComponentInParent<Map>();
        //Debug.Log(map);
    }
    
    void OnMouseEnter()
    { 
        Highlight();
        Map map = GetComponentInParent<Map>();
        List<MapNode> adjNodes = map.AdjacentNodes(GetComponent<Tile>().nodeInfo);
        foreach (MapNode mn in adjNodes)
        {
            map.TileAt(mn).gameObject.GetComponent<HighlightScript>().Highlight();
        }
    }

    void OnMouseExit()
    {
        Revert();
        Map map = GetComponentInParent<Map>();
        List<MapNode> adjNodes = map.AdjacentNodes(GetComponent<Tile>().nodeInfo);
        foreach (MapNode mn in adjNodes)
        {
            map.TileAt(mn).gameObject.GetComponent<HighlightScript>().Revert();
        }
    }
   
    public void Highlight() => GetComponent<Renderer>().material = Materials.Instance.highlight;
    public void Revert() => GetComponent<Renderer>().material = tileMaterial;
}
