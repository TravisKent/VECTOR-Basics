using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0;i < 20; i++) 
        {
             if(Input.GetKeyDown("joystick 1 button "+i))
             {
                 print("joystick 1 button "+i);
             }

              if(Input.GetKeyDown("joystick 2 button "+i))
             {
                 print("joystick 2 button "+i);
             }
         }
         
         //Debug.Log(Input.GetAxis("Vertical"));
          if (Input.GetAxis("Vertical")>0)
          {
            Debug.Log(" joystick moving up");
          }
          else if (Input.GetAxis("Vertical")<0)
          {
            Debug.Log(" joystick moving down");
          }
          else if (Input.GetAxis("Vertical")==0)
          {
           // Debug.Log(" joystick not moving up or down");
          }

           //Debug.Log(Input.GetAxis("Horizontal"));
          if (Input.GetAxis("Horizontal")>0)
          {
            Debug.Log(" joystick moving RIGHT");
          }
          else if (Input.GetAxis("Horizontal")<0)
          {
            Debug.Log(" joystick moving LEFT");
          }
          else if (Input.GetAxis("Horizontal")==0)
          {
           // Debug.Log(" joystick not moving up or down");
          }
          
    }
}

 
