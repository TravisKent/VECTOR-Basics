using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrKfireProjectile_1 : MonoBehaviour
{

    public GameObject projectile;
    public Transform firePointPosition;
    public Transform firePointRotation;
    public float shotDelay;
    private float myTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTimer = myTimer- Time.deltaTime;

        //fire button and the shot delay is less than zero
        if(Input.GetKeyDown(KeyCode.Space) &&(myTimer<=0) )
        {
            //reset the shot timer
            myTimer = shotDelay;
            Instantiate(projectile, firePointPosition.transform.position, firePointRotation.transform.rotation);
        }
    }
}
