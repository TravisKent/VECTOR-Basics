using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MScursormovement : MonoBehaviour
{
   public bool player01, player02;
   private float yval, xval;
   public float moveSpeed;
   public Rigidbody2D theRB;
   public Transform bottomLeftLimit, topRightLimit;

    
    void Start()
    {

    }
    void Update()
    {
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
        theRB.velocity = new Vector2(xval, yval)*moveSpeed;
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y), transform.position.z);

        if(player01 == true) 
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
    }

    public void GetPlayerMoveInput(int playerNumber)
    {
        if(playerNumber == 1)
        {
            if(Input.GetKeyDown("w"))
            {
                Debug.Log("W was pressed");
                yval = 1.0f;
            }
            if(Input.GetKeyDown("s"))
            {
                Debug.Log("s was pressed");
                yval = -1.0f;
            }
            if(Input.GetKeyDown("a"))
            {
                Debug.Log("a was pressed");
                xval = -1.0f;
            }
            if(Input.GetKeyDown("d"))
            {
                Debug.Log("d was pressed");
                xval = 1.0f;
            }

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
        }
        else if(playerNumber == 2)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("UpArrow was pressed");
                yval = 1.0f;
            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("DownArrow was pressed");
                yval = -1.0f;
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("LeftArrow was pressed");
                xval = -1.0f;
            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("RightArrow was pressed");
                xval = 1.0f;
            }

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
        }

    }
}

