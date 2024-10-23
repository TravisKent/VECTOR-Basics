using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZmFireProjectile : MonoBehaviour
{
public GameObject projectile;
public Transform firePointPosition;
public Transform firePointRotation;
public float shotDelay;
float myTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    

        myTimer = myTimer-Time.deltaTime;




        //fire Button
        if(Input.GetKeyDown(KeyCode.Space) && (myTimer <=0))
        {
            //RESET THE SHOT TIMER
            myTimer = shotDelay;
            Instantiate(projectile,firePointPosition.transform.position, firePointRotation.transform.rotation);

            
        } 
        



    }
}