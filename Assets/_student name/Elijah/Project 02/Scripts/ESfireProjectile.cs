using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESfireProjectile : MonoBehaviour

{
    public bool joystickActivated;
    public KeyCode p1button01, p1button02;
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

        //fire button
        if(Input.GetKeyDown(KeyCode.Space) && (myTimer <=0))
        {
            //reset the shot timer
            myTimer = shotDelay;
            Instantiate(projectile, firePointPosition.transform.position, firePointRotation.transform.rotation);
        }


        if(joystickActivated)
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
