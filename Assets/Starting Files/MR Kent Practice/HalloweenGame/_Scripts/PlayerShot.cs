using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public bool Player01Bullet, Player02Bullet;
    public float shotSpeed = 7f;

    public GameObject impactEffect;
    public GameObject SpaceExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.tag =="Player")
        {
            //Do Nothing
        }
        else if(other.tag =="Bullignore")
        {
            //Do Nothing
        }
        else if (other.tag =="Minion")
        {
            int minionHitReward = 1;
            other.gameObject.GetComponent<MinonBullet>().DestroyThisGameObjectAndParent();
            Instantiate(SpaceExplosion, other.transform.position, other.transform.rotation);
            if(Player01Bullet)
                {
                    GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().AddPointsPlayer01(minionHitReward);
                }
                else if(Player02Bullet)
                {
                    GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().AddPointsPlayer02(minionHitReward);
                }
            Destroy(this.gameObject);
        }
        else
        {       
            Instantiate(impactEffect, transform.position, transform.rotation);

            if(other.tag =="Halloween Object")
            {
                //testing this line
                SpawnAfterDestruction whatWeHit =  other.gameObject.GetComponent<SpawnAfterDestruction>(); 
                if(Player01Bullet)
                {
                    GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().AddPointsPlayer01(whatWeHit.points);
                }
                else if(Player02Bullet)
                {
                    GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().AddPointsPlayer02(whatWeHit.points);
                }
                whatWeHit.SpawnObj();
       
                Instantiate(SpaceExplosion, other.transform.position, other.transform.rotation);

                //Destroy(other.gameObject);
            }
            if(other.tag == "BossPart")
            {
                int bossHitReward = 5;
                other.GetComponent<BossPartHealthSystem>().TakeDamage();
                if(Player01Bullet)
                {
                    GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().AddPointsPlayer01(bossHitReward);
                }
                else if(Player02Bullet)
                {
                    GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().AddPointsPlayer02(bossHitReward);
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
