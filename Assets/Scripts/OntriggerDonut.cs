using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OntriggerDonut : MonoBehaviour
{
    private TextMeshProUGUI text;
    public GameObject obj;
    private void Start()
    {
        obj = GameObject.Find("DonutCurrency");
        text = obj.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SaveSystem.saveDate(SaveSystem.loadData().highScore, SaveSystem.loadData().donuts + 1);
            updateDisplay();
            Destroy(this.gameObject);
        }

    }
   void updateDisplay()
    {
        

        text.text = SaveSystem.loadData().donuts.ToString();
        

    }
}
