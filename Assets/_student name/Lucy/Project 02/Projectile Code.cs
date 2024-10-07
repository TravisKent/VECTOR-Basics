using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHfireProjectile_1 : MonoBehaviour
{
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

    }
}
