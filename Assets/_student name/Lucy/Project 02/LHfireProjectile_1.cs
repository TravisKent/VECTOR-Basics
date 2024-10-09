using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHfireProjectile_1 : MonoBehaviour
{
   //NEW CODE
    public bool joySTickActivated;
     public KeyCode p1button01, p1button02;
    public GameObject projectile;
    public Transform firePointPosistion;
    public Transform firePointRotation;
    public float shotDelay;
    private float myTimer;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      myTimer = myTimer-Time.deltaTime;


      //fire button
      if(Input.GetKeyDown(KeyCode.Space)&&(myTimer<=0))
      {
        //reset the shot timer
        myTimer = shotDelay;
        Instantiate(projectile, firePointPosistion.transform.position, firePointPosistion.transform.rotation);
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
                Instantiate(projectile, firePointPosistion.transform.position, firePointRotation.transform.rotation);
            }
        }
    }
}
