using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKjoystickTester : MonoBehaviour
{
    public SpriteRenderer mySprite;
    public Color MC0, MC1, MC2, MC3, MC4, MC5, MC6, MC7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.JoystickButton0))
        {
           
            mySprite.color = MC0; 
            /*
            string[] jsname =Input.GetJoystickNames();
            Debug.Log(jsname[0]);
            Debug.Log(jsname[1]);
            Debug.Log(jsname[2]);
            */
           if( Input.GetKey(KeyCode.Joystick3Button0))
           {
            Debug.Log("joysitk 3?");
           }
            
        }
        else if(Input.GetKey("joystick 1 button "+ 1 ))
        {
            mySprite.color = MC1; 
        }
        else
        {
            mySprite.color = Color.white;
        }
        
    }
}
