using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpawnAfterDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    

    public int points;
    public int sheildPoints;
    public int targetShieldValue;
    public GameObject ObjectToSpawn;
    public Sprite[] shieldLevels;
    public SpriteRenderer mySprite;
    public TargetSpawner mySpawner;
    // Start is called before the first frame update
    void Start()
    {
        mySpawner = GameObject.Find("Target Spawner").GetComponent<TargetSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObj(int bulletStrength)
    {
        sheildPoints-= bulletStrength; 
        if(sheildPoints>=0)
        {
            mySprite.sprite = shieldLevels[sheildPoints];
        }
        else if(sheildPoints<0)
        {
            Instantiate(ObjectToSpawn, this.transform.position, this.transform.rotation);
            mySpawner.IncreaseTargetDestroyed();
            Destroy(gameObject);
        }
    }


}
