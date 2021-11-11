using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectWithTimer : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] float spawnRate=1f;
    [SerializeField] GameObject spawn;
    float timeCounter=0;
    enum Stat { WAITING,SPAWNING}
    [SerializeField] Stat st = Stat.WAITING;
    void Update()
    {
        spawn.transform.rotation = Random.rotation;
      if(st == Stat.WAITING)
        {
          st = Stat.SPAWNING;
            StartCoroutine(spawner());
        
        }
    }



    IEnumerator spawner()
    {
        
        GameObject gameObject = Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawn.transform.position, spawn.transform.rotation);
        gameObject.transform.parent = GameObject.Find("ObstaclesHolder").transform;
        yield return new WaitForSeconds(1 / spawnRate);
        st = Stat.WAITING;
    }
}
