using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPartHealthSystem : MonoBehaviour
{
    public int health;
    public SpriteRenderer bpSpriteControll;
    public float damageTime;
    public float timerCounter;
    public bool takeingDamageEffect;
    public GameObject bossPart;
    public GameObject particaleEffect;

    //spawing System
    public bool SpawnerACTIVE=false;
        public GameObject[] targetsToSpawn;
        public Transform spawnLocation;
        public float spawnTimer;
        public float timeSpawn;
        public int spawnTargetCounter=0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            //turn off the boss part
            Instantiate(particaleEffect, this.transform.position, this.transform.rotation);
            bossPart.SetActive(false);
        }
        if(takeingDamageEffect)
        {
            //color the image overlay
            bpSpriteControll.color  = Color.red;
            timerCounter = timerCounter- Time.deltaTime;
            if(timerCounter<=0)
            {
                bpSpriteControll.color  = Color.white;
                takeingDamageEffect = false;
            }
        }

        if(SpawnerACTIVE)
        {
            SpawnGrave();
        }
    }


    public void TakeDamage()
    {
        health = health-1;
        takeingDamageEffect = true;
        timerCounter = damageTime;
    }




    public void SpawnGrave()
    {
        
            

        timeSpawn -= Time.deltaTime;
        if(timeSpawn<0)
        {
           
            //spawn bad guy
            GameObject newSpawn = Instantiate(targetsToSpawn[spawnTargetCounter], spawnLocation.position, spawnLocation.rotation);
            //setup his path to follow
        
            timeSpawn = spawnTimer;

            spawnTargetCounter++;
            if(spawnTargetCounter > targetsToSpawn.Length-1)
            {
                spawnTargetCounter=0;
            }
        }
        

    }
    
}
