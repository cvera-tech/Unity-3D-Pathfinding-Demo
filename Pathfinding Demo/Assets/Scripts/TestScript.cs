using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Map testMap = new Map();
        testMap.PrintGraph();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
