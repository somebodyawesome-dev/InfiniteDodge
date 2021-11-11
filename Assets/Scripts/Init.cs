using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Init : MonoBehaviour
{
    
    void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = SaveSystem.loadData().donuts.ToString();

    }

    
}
