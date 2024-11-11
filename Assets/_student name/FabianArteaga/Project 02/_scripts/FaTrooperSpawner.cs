using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaTrooperSpawner : MonoBehaviour
{
    public GameObject[] targetsToSpawn;
    public Transform spawnLocation;
    public float spawnTimer;
    public float timeCounter;
    public int spawnTargetCounter=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;
        if(timeCounter<0)
        { //setup path object
        
        GameObject newSpawn= Instantiate(targetsToSpawn[spawnTargetCounter], spawnLocation.position, Quaternion.identity);
        
        //reset clock
        timeCounter = spawnTimer;

        spawnTargetCounter++;
        if(spawnTargetCounter > targetsToSpawn.Length-1)
        {
            spawnTargetCounter=0;
        }
        }
    }
}
