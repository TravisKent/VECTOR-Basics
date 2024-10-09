using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLO_fireprojectile : MonoBehaviour
{
    public bool joystickactivated;
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
      myTimer = myTimer- Time.deltaTime;


      //fire Button
      if(Input.GetKeyDown(KeyCode.Space) && (myTimer <=0)) 
      {
        //reset the shot timer
        myTimer = shotDelay;
        Instantiate(projectile, firePointPosition.transform.position, firePointRotation.transform.rotation);
      }

      if(joystickactivated)
      {
        if(Input.GetKeyDown(p1button01))
      {
        Debug.Log("joystick button 0 pressed");
        //reset the shot timer
        myTimer = shotDelay;
        Instantiate(projectile, firePointPosition.transform.position, firePointRotation.transform.rotation);
      }


      }



    }
}