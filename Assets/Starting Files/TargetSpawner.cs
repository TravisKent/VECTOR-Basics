using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public int targetsDestroyed; 
    public int maxVal=11;
    public float[] targetSpawnProbabilites;
    public GameObject[] targetsToSpawn;

    public Transform[] spawnLocations;
    public float spawnTimer;
    public float timeCounter;
    int spawnLocationCounter=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;
        if(timeCounter<0)
        {
            //spawn new target
            if(targetsDestroyed<=10)
            {
                
                Instantiate(targetsToSpawn[0], spawnLocations[spawnLocationCounter].position, Quaternion.identity);
                spawnLocationCounter++;
                if(spawnLocationCounter >= spawnLocations.Length)
                {
                    spawnLocationCounter = 0;
                }
            }
            else
            {
                spawnLocationCounter++;
                if(spawnLocationCounter >= spawnLocations.Length)
                {
                    spawnLocationCounter = 0;
                }
                
                //generate random number
                int randNumInt = Random.Range(0, maxVal);
                Instantiate(targetsToSpawn[randNumInt], spawnLocations[spawnLocationCounter].position, Quaternion.identity);
                
            }

            if( (targetsDestroyed >=10) && (targetsDestroyed <20))
            {
                spawnTimer = 2.5f;
            }
            else if( (targetsDestroyed >=20) && (targetsDestroyed <50))
            {
                spawnTimer = 1.5f;
            }
            else if( (targetsDestroyed >=50)  )
            {
                spawnTimer = 1.0f;
            }
            //reset clock
            timeCounter = spawnTimer;    

        }
    }

    public void IncreaseTargetDestroyed()
    {
        targetsDestroyed++;
    }
}
