using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bossToSpawn;
    public GameObject parentObject;
    public bool setToDestroy=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(setToDestroy)
        {
            Destroy(parentObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name =="SPN_Boss")
        {
            Debug.Log("Spawn Boss");
            Instantiate(bossToSpawn, spawnPoint.position, spawnPoint.rotation);
            setToDestroy = true;
        }
    } 
}
