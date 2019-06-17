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
    }
    void OnMouseEnter()
    { 
        Highlight();
        List<Node> adjNodes = GetComponent<Node>().AdjacentNodes(GetComponentInParent<Map>());
        foreach (Node n in adjNodes)
        {
            n.gameObject.GetComponent<HighlightScript>().Highlight();
        }
    }

    void OnMouseExit()
    {
        Revert();
        List<Node> adjNodes = GetComponent<Node>().AdjacentNodes(GetComponentInParent<Map>());
        foreach (Node n in adjNodes)
        {
            n.gameObject.GetComponent<HighlightScript>().Revert();
        }
    }

    public void Highlight() => GetComponent<Renderer>().material = Materials.Instance.highlight;
    public void Revert() => GetComponent<Renderer>().material = tileMaterial;
}
