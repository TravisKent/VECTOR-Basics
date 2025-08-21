using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DPTrooperSpawner : MonoBehaviour
{
public GameObject[] targetsToSpawn;
public Transform spawnLocation;
public float spawnTimer;
public float timeCounter;
public int spawnTaargetCounter=0;
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
GameObject newSpawn = Instantiate(targetsToSpawn[spawnTaargetCounter],
spawnLocation.position, Quaternion.identity);
//reset clock
timeCounter = spawnTimer;
spawnTaargetCounter++;
if(spawnTaargetCounter > targetsToSpawn.Length-1)
{
spawnTaargetCounter=0;
}
}
}
}
