using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraceEnemySpawner : MonoBehaviour
{
    public GameObject[] targetsToSpawn;
    public Transform spawnLocation;
    public float spawnTimer;
    public float timeCounter;
    public int spawnTargetCounter=0;
    public string pathName="Enemy Path";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter-=Time.deltaTime;
        if(timeCounter<0)
        {
            //setup path object
            GameObject pathGameObject;
            pathGameObject=GameObject.Find(pathName);
            //spawn badguy
            GameObject newSpawn=Instantiate(targetsToSpawn[spawnTargetCounter], spawnLocation.position, Quaternion.identity);
            //setup his path to follow
            newSpawn.GetComponent<PathFollowerScript>().PathToFollow =pathGameObject.GetComponent<PathEditorScript>();
            newSpawn.GetComponent<PathFollowerScript>().speed=4.35f;
            timeCounter=spawnTimer;
            spawnTargetCounter++;
            if(spawnTargetCounter>targetsToSpawn.Length-1)
            {
                spawnTargetCounter=0;
            }
        }
    }
}
