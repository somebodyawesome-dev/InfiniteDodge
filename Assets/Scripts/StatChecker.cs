using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatChecker : MonoBehaviour
{
    enum spawnStat {WAITING,SPAWNING}
    spawnStat stat;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            stat = spawnStat.SPAWNING;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            stat = spawnStat.WAITING;
        }
    }
    private void Update()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
        if (colliders == null)
        {
            stat = spawnStat.WAITING;
            Debug.Log("safsaf");
        }
    }
    public bool isReady()
    {
        if (stat == spawnStat.WAITING) return true;
        else return false;
    }

}
