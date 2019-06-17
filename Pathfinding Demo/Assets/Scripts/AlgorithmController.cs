using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlgorithmController : MonoBehaviour
{
    public Canvas canvas;
    private string currentAlgorithm;
    // Start is called before the first frame update
    void Start()
    {
        TMP_Dropdown dropdown = canvas.GetComponentInChildren<TMP_Dropdown>();
        int currentValue = dropdown.value;
        Debug.Log(currentValue);
        currentAlgorithm = dropdown.options[currentValue].text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAlgorithm()
    {
        currentAlgorithm = canvas.GetComponentInChildren<TMP_Dropdown>().options[canvas.GetComponentInChildren<TMP_Dropdown>().value].text;
        Debug.Log(currentAlgorithm);
    }
}
