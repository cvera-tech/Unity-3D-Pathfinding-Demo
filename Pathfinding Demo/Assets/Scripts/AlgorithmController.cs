using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlgorithmController : MonoBehaviour
{
    public Canvas canvas;
    private string currentAlgorithmName;
    private bool algorithmRunning;
    private LayerMask tileMask;
    public Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        TMP_Dropdown dropdown = canvas.GetComponentInChildren<TMP_Dropdown>();
        int currentValue = dropdown.value;
        currentAlgorithmName = dropdown.options[currentValue].text;
        algorithmRunning = false;
        tileMask = LayerMask.GetMask("Tiles");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    // Primary click
        {
            RaycastHit hitInfo;
            bool raycastSuccess = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, tileMask);
            if (raycastSuccess)
            {
                hitInfo.transform.GetComponent<Tile>().SelectStart();
            }
            
        }
        if (Input.GetMouseButtonDown(1))    // Secondary click
        {
            RaycastHit hitInfo;
            bool raycastSuccess = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, tileMask);
            if (raycastSuccess)
            {
                hitInfo.transform.GetComponent<Tile>().SelectEnd();
            }
        }
    }

    public void ChangeAlgorithm()
    {
        currentAlgorithmName = canvas.GetComponentInChildren<TMP_Dropdown>().options[canvas.GetComponentInChildren<TMP_Dropdown>().value].text;
        Debug.Log(currentAlgorithmName);
    }

    public void Begin()
    {
        if (algorithmRunning)
        {
            // Reset the map
        }
        algorithmRunning = true;
    }

    public void Pause()
    {

    }

    public void Step()
    {

    }

    public void End()
    {

    }
}
