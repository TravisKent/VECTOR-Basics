using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyPowerUP : MonoBehaviour
{
    public AudioSource sfx;
    public GameObject particalEffect;
    public int points = 126;
    public GameObject img;
    public CircleCollider2D myCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            sfx.Play();
            other.GetComponent<PlayerController>().TurnOnPowerUP();
            if( other.GetComponent<PlayerController>().player01)
            {
                GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().AddPointsPlayer01(points);
            }
            else if(other.GetComponent<PlayerController>().player02)
            {
                GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().AddPointsPlayer02(points);
            }
            Instantiate(particalEffect, this.transform.position, this.transform.rotation);
            img.SetActive(false);
            myCol.enabled = false;
            Destroy(gameObject,3f);
        }
    }
}
