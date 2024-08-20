using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotSpace : MonoBehaviour
{
    public bool Player01Bullet, Player02Bullet;
    public float shotSpeed = 7f;
    public int bulletSheildBreakerValue = 0;

    public GameObject impactEffect;
    public GameObject SpaceExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
        transform.position += transform.TransformDirection (Vector2.right)*shotSpeed*Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.tag =="Player")
        {
            //Do Nothing
        }
        else
        {       
            Instantiate(impactEffect, transform.position, transform.rotation);

            if(other.tag =="Halloween Object")
            {
                //testing this line
                SpaceSpawnAfterDestruction whatWeHit =  other.gameObject.GetComponent<SpaceSpawnAfterDestruction>(); 
                if(whatWeHit.targetShieldValue <= bulletSheildBreakerValue )
                {
                    if(Player01Bullet)
                    {
                        GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().AddPointsPlayer01(whatWeHit.points);
                    }
                    else if(Player02Bullet)
                    {
                        GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().AddPointsPlayer02(whatWeHit.points);
                    }
                    whatWeHit.SpawnObj(bulletSheildBreakerValue+1);
        
                    Instantiate(SpaceExplosion, other.transform.position, other.transform.rotation);

                    //Destroy(other.gameObject);
                }
            }

            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
