using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARVCursorMovement : MonoBehaviour
{
//Player Select Variables 
public bool player01, player02; 
//variables to store x and y values 
private float yval, xval; 
//variable to control the movement speed of the cursor 
public float moveSpeed; 
//2D rigidbody used for physics calculations 
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
    //Detect which player this script is attached to and then detect the keys they press for movement 2 
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
    transform.position = new Vector3( Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y), transform.position.z); 
    
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
        Debug.Log ("No Player Was Selected" ); 
    }
    */ 
    }
    // function/method that detects the player input and assigns values to be used with the velocity
    public void GetPlayerMoveInput (int playerNumber) 
    { 
        if ( playerNumber==1) 
        { 
            // check if button is pressed 
            if (Input.GetKeyDown("w")) 
            { 
                Debug.Log("W was pressed" ); yval = 1.0f; 
            }
            if (Input.GetKeyDown("s")) 
            { 
                Debug.Log("s was pressed"); yval = -1.0f; 
            }
            if (Input.GetKeyDown("a")) 
            { Debug.Log("a was pressed"); xval = -1.0f; 
            }
            if (Input.GetKeyDown("d")) 
            { 
                Debug.Log("d was pressed"); xval = 1.0f; 
            } 
            // c h e c k if b u t t o n is r ele a s e d 
            if(Input.GetKeyUp("w")) 
            {
                Debug.Log("W was released" ); yval = 0.0f; 
            }
            if(Input.GetKeyUp("s")) 
            { 
                Debug.Log("s was released"); yval = 0.0f; 
            }
            if(Input.GetKeyUp("a")) 
            { 
                Debug.Log("a was released"); xval = 0.0f; 
            }
            if(Input.GetKeyUp("d")) 
            { 
                Debug.Log("d was released"); xval = 0.0f; 
            } 
        }
        else if ( playerNumber==2 ) 
        { 
            //check if button is pressed 
            if (Input.GetKeyDown(KeyCode.UpArrow)) 
            { 
                Debug.Log ( "Up Arrow was pressed" ); yval = 1.0f; 
            }
            if (Input.GetKeyDown(KeyCode.DownArrow ) ) 
            { 
                Debug.Log( "Down Arrow was pressed"); yval = -1.0f; 
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) ) 
            { Debug.Log ( "Left Arrow was pressed"); xval = -1.0f; 
            }
            if (Input.GetKeyDown(KeyCode.RightArrow ) ) 
            { 
                Debug.Log ( "Right Arrow was pressed"); xval = 1.0f; 
            }
            //Check if button is released 
            if(Input.GetKeyUp(KeyCode.UpArrow)) 
            { 
                Debug.Log("Up Arrow was released"); yval = 0.0f; 
            }
            if(Input.GetKeyUp(KeyCode.DownArrow)) 
            { 
                Debug.Log("DownArrow was released"); yval = 0.0f; 
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow)) 
            { 
                Debug.Log("LeftArrow was released"); xval = 0.0f; 
            }
            if(Input.GetKeyUp(KeyCode.RightArrow)) 
            { 
                Debug.Log ( "Right Arrow was pressed"); xval = 0.0f; 
            } 
        } 
    }
} 
