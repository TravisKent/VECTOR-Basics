using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMFireProjectile : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePointPosition;
    public Transform firePointrotation;
    public float shotDelay;
    float myTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTimer = myTimer- Time.deltaTime;


        //fire Button
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //reset the shot timer
            myTimer = shotDelay;
            Instantiate(projectile, firePointPosition.transform.position, firePointrotation.transform.rotation);
        }
    }
}
