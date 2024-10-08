using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DPfireprojectile : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePointPosition;
    public Transform firePointRotation;
    public float shotdelay;
    private float myTimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTimer = myTimer- Time.deltaTime;

        //fire button and the shot delay is ess than zero
        if(Input.GetKeyDown(KeyCode.Space) &&(myTimer<=0) )
        {
            //rest the shot timer
            myTimer = shotdelay;
            Instantiate(projectile, firePointPosition.transform.position, firePointRotation.transform.rotation);
        }
        
        
    }
}
