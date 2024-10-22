using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinonBullet : MonoBehaviour
{

    
    public float launchVelocity = 10f;
    public Rigidbody2D rb;
    public float shotSpeed = 7f;

    public GameObject impactEffect;
    public GameObject SpaceExplosion;

    public int playerHit=0;
    public int bulletPointDrain=10;
    public int minionHealth = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.tag =="Player")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            //Determine Player
            if(other.GetComponent<PlayerController>().player01)
            {
                playerHit = 1;
                GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().SubtractPointsPlayer01(bulletPointDrain);
                other.GetComponent<playerHealthSystem>().PlayerTakeDamage();
                Instantiate(SpaceExplosion, other.transform.position, other.transform.rotation);
            }
            else if(other.GetComponent<PlayerController>().player02)
            {
                playerHit = 2;
                GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().SubtractPointsPlayer02(bulletPointDrain);
                other.GetComponent<playerHealthSystem>().PlayerTakeDamage();
                Instantiate(SpaceExplosion, other.transform.position, other.transform.rotation);
            }
            if(other.GetComponent<PlayerController>().player03)
            {
                playerHit = 3;
               // GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().SubtractPointsPlayer01(bulletPointDrain);
                other.GetComponent<playerHealthSystem>().PlayerTakeDamage();
                Instantiate(SpaceExplosion, other.transform.position, other.transform.rotation);
            }
            if(other.GetComponent<PlayerController>().player04)
            {
                playerHit = 4;
               // GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().SubtractPointsPlayer01(bulletPointDrain);
                other.GetComponent<playerHealthSystem>().PlayerTakeDamage();
                Instantiate(SpaceExplosion, other.transform.position, other.transform.rotation);
            }
            
            Destroy(this.gameObject.transform.parent.gameObject);

        }
        else
        {  
            //do nothing     
           // Instantiate(impactEffect, transform.position, transform.rotation);

           

           // Destroy(this.gameObject);
        }
    }

    public void DestroyThisGameObjectAndParent()
    {
        minionHealth--;
        if(minionHealth<=0)
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
