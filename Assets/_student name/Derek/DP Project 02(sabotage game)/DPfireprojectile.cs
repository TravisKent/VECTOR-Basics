using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DPfireprojectile : MonoBehaviour
{
     public bool joySTickActivated;
    public KeyCode p1button01, p1button02;
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
        myTimer=myTimer- Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && (myTimer<=0))
        {
            myTimer=shotDelay;
            Instantiate(projectile, firePointPosition.transform.position, firePointRotation.transform.rotation);
        }
         if(joySTickActivated)
        {
            //fire Button
             if(Input.GetKeyDown(p1button01))
            {
                Debug.Log(p1button01+" pressed");
                //check if obhect is clicked on
                //reset the shot timer
                myTimer = shotDelay;
                Instantiate(projectile, firePointPosition.transform.position, firePointRotation.transform.rotation);
            }
        }
    }
}
