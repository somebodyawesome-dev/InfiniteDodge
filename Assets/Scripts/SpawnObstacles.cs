using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] GameObject[] spawns;
    [SerializeField] int level;
    [SerializeField] float spawningRate;
    enum spawnerStat {SPAWNING,WAITING};
    spawnerStat stat;
    // Start is called before the first frame update
    private void Awake()
    {
       
    }
    private void Start()
    {
        spawns = GameObject.FindGameObjectsWithTag("Spawn");
        stat = spawnerStat.WAITING;
        level = 1;
        spawningRate = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(stat == spawnerStat.WAITING)
        {
            //spawn obstacles
            stat = spawnerStat.SPAWNING;
            StartCoroutine(spawn());
            level++;
            spawningRate += 0.05f;
        }
    }
   

    IEnumerator spawn()
    {
        int numberOfObstacles = Random.Range( 1 , level+1 );

        while (numberOfObstacles > 0)
        {
            int numberOfobstaclesAtTime = Random.Range(1, spawns.Length - 2);
            for(int i =0; i < numberOfobstaclesAtTime; ++i)
            {
                int spawnId = Random.Range(0, spawns.Length);
                if (spawns[spawnId].GetComponent<StatChecker>().isReady())
                {
                   GameObject gameObject= Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawns[spawnId].transform.position,spawns[spawnId].transform.rotation);
                    gameObject.transform.parent = GameObject.Find("ObstaclesHolder").transform;
                }

            }

            yield return new WaitForSeconds(1);
            numberOfObstacles -= numberOfobstaclesAtTime;
        }

        yield return new WaitForSeconds(1);
        stat = spawnerStat.WAITING;
    }
}
