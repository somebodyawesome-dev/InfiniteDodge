using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float time;
    float timeCounter;
    private void Start()
    {
        timeCounter = 5f;
    }
    private void Update()
    {
        if(timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
