using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKCursorMovement : MonoBehaviour
{
    public KeyCode p1Up, p1Down, p1Left, p1Right, p1button01, p1button02, p1button03, p1button04;
    public KeyCode p2Up, p2Down, p2Left, p2Right, p2button01, p2button02, p2button03, p2button04;
    //Player Select Variables
    public bool player01, player02;
    //variables to store x and y values
    private float yval, xval;

    //variable to control the movement speed of the cursor
    public float moveSpeed;
    
    //2D ridigidbody used for physics calculations 
    public Rigidbody2D theRB;
    
    //XYZ positions that are used to limit the cursor movement horizontally and vertically
    public Transform bottomLeftLimit, topRightLimit;
   
   
    // Start is called before the first frame update  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Detect which player this script is attached to and then detect the keys they press for movement  
        if(player01==true)
        {
            GetPlayerMoveInput(1);
        }
        else if(player02 == true)
        {
            GetPlayerMoveInput(2);
        }
        else
        {
            Debug.Log("No Player Was Selected");
        }

        //use the rigidbody to add velocity gathered from the player input, and scaled by the speed
        theRB.velocity = new Vector2(xval, yval)*moveSpeed;
        //move the game object attached to this script but limit the movement within the values/border limits set in the variables  
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y),  transform.position.z);

        //Code to be used later
                /*
                if(player01==true)
                {
                GetPlayerFireInput(1);
                
                }
                else if(player02 == true)
                {
                    GetPlayerFireInput(2);
                
                }
                else
                {
                    Debug.Log("No Player Was Selected");
                }
                */
    }

    //function/method that detects the player input and assigns values to be used with the velocity
     public void GetPlayerMoveInput(int playerNumber)
    {
        if(playerNumber==1)
        {
            
            //check if button is pressed
            if (Input.GetKeyDown(p1Up))
            {
                Debug.Log( p1Up +"was pressed");
                yval = 1.0f;
            }
            if (Input.GetKeyDown(p1Down))
            {
                Debug.Log(p1Down +" was pressed");
                yval = -1.0f;
            }
            if (Input.GetKeyDown(p1Left))
            {
                Debug.Log(p1Left+" was pressed");
                xval = -1.0f;
            }
            if (Input.GetKeyDown(p1Right))
            {
                Debug.Log(p1Right+ " was pressed");
                xval = 1.0f;
            }
            
            //check if button is released
            if(Input.GetKeyUp(p1Up))
            {
                Debug.Log(p1Up+ " was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(p1Down))
            {
                Debug.Log(p1Down +" was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(p1Left))
            {
                Debug.Log(p1Left+ " was released");
                xval = 0.0f;
            }
            if(Input.GetKeyUp(p1Right))
            {
                Debug.Log(p1Right+" was released");
                xval = 0.0f;
            }
            /*//old version
            //check if button is pressed
            if (Input.GetKeyDown("w"))
            {
                Debug.Log("W was pressed");
                yval = 1.0f;
            }
            if (Input.GetKeyDown("s"))
            {
                Debug.Log("s was pressed");
                yval = -1.0f;
            }
            if (Input.GetKeyDown("a"))
            {
                Debug.Log("a was pressed");
                xval = -1.0f;
            }
            if (Input.GetKeyDown("d"))
            {
                Debug.Log("d was pressed");
                xval = 1.0f;
            }
            
            //check if button is released
            if(Input.GetKeyUp("w"))
            {
                Debug.Log("W was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp("s"))
            {
                Debug.Log("s was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp("a"))
            {
                Debug.Log("a was released");
                xval = 0.0f;
            }
            if(Input.GetKeyUp("d"))
            {
                Debug.Log("d was released");
                xval = 0.0f;
            }
            */
        }
        else if(playerNumber ==2)
        {

            //check if button is pressed
            if (Input.GetKeyDown(p2Up))
            {
                Debug.Log( p2Up +"was pressed");
                yval = 1.0f;
            }
            if (Input.GetKeyDown(p2Down))
            {
                Debug.Log(p2Down +" was pressed");
                yval = -1.0f;
            }
            if (Input.GetKeyDown(p2Left))
            {
                Debug.Log(p2Left+" was pressed");
                xval = -1.0f;
            }
            if (Input.GetKeyDown(p2Right))
            {
                Debug.Log(p2Right+ " was pressed");
                xval = 1.0f;
            }
            
            //check if button is released
            if(Input.GetKeyUp(p2Up))
            {
                Debug.Log(p2Up+ " was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(p2Down))
            {
                Debug.Log(p2Down +" was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(p2Left))
            {
                Debug.Log(p2Left+ " was released");
                xval = 0.0f;
            }
            if(Input.GetKeyUp(p2Right))
            {
                Debug.Log(p2Right+" was released");
                xval = 0.0f;
            }
            /*
            //old version
            //check if button is pressed
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("UpArrow was pressed");
                yval = 1.0f;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("DownArrow was pressed");
                yval = -1.0f;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("LeftArrow was pressed");
                xval = -1.0f;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("RightArrow was pressed");
                xval = 1.0f;
            }
            
            //Check if button is released
            if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                Debug.Log("UpArrow was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                Debug.Log("DownArrow was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Debug.Log("LeftArrow was released");
                xval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                Debug.Log("RightArrow was released");
                xval = 0.0f;
            }
            */ 
        }
    }
}
