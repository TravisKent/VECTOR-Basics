using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;

public class ChopperSpawner : MonoBehaviour
{
    public GameObject[] targetsToSpawn;
    public Transform spawnLocation;
    public float spawnTimer;
    public float timeCounter;
    public int spawnTargetCounter=0;
    //public  GameObject pathGameObject;//used for debugging

    //find and set path variables
    public string pathName = "Chopper Path";
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
             // setup path object
            GameObject pathGameObject;
            pathGameObject = GameObject.Find(pathName);
            //spawn badguy
            GameObject newSpawn = Instantiate(targetsToSpawn[spawnTargetCounter], spawnLocation.position, Quaternion.identity);
            //setup his path to follow
            newSpawn.GetComponent<PathFollowerScript>().PathToFollow = pathGameObject.GetComponent<PathEditorScript>();
            //setspeed
            newSpawn.GetComponent<PathFollowerScript>().speed = 4.35f;

            //reset clock
            timeCounter = spawnTimer;

            spawnTargetCounter++;
            if(spawnTargetCounter >  targetsToSpawn.Length-1)
            {
                spawnTargetCounter=0;
            }
        }
    }

    
}
