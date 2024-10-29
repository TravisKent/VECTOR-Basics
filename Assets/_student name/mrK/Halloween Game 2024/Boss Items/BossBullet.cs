using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{

    public float launchVelocity = 10f;
    public Rigidbody2D rb;
    public float shotSpeed = 7f;

    public GameObject impactEffect;
    public GameObject SpaceExplosion;

    public int playerHit=0;
    public int bulletPointDrain=10;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(launchVelocity, 0f));
    }
    void Awake()
    {
/*
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector3(launchVelocity, 0f , 0f));
        */
    }
    

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
      if(Input.GetKeyDown(KeyCode.Space))
      {
        Debug.Log("Adding Foce to bullet");
        MyaddForce();
      }

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
            
            Destroy(this.gameObject);

        }
        else
        {  
            //do nothing     
           // Instantiate(impactEffect, transform.position, transform.rotation);

           

           // Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void MyaddForce()
    {        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(launchVelocity, 0f ));
    }
}
