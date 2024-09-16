using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESmjouseController : MonoBehaviour
{
     public GameObject Thing;
     public GameObject objSelected = null;

    //list of game objects that will be used as snap points 
    public GameObject[] snapPoints;
    //variable to bue used aas a radial distance check for the snap points
    public float snapSensitivity = 2.0f;

    //variable that can be used for the z distance offset
    public float clipplaneOffset;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //display a debug racy where mouse is taking effect
        Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(newRay.origin, newRay.direction*25, Color.green);

            //code for gettiung left mouse button click
            if(Input.GetMouseButtonDown(0))
            {
            Debug.Log( "Mouse Button Pressed");
            CheckHitObject();
            }
            //code for releasing the mouse
            if(Input.GetMouseButtonUp(0) && objSelected !=null)
            {
                Debug.Log( "Mouse Button is released");
                //drop the object
                DropObject();
            }
            //code for dragging with the mouse
            if(Input.GetMouseButton(0) && objSelected !=null)
            {
                Debug.Log("Mouse Button is being Held");
                //dragging object
                DragObject();
            }





//comment out old code
/*
         if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("BAZINGA");
            Thing.transform.position=new Vector3(3f,3f,0f);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("AWWWW MAN");
            Thing.transform.position=new Vector3(-3f,-3f,0f);
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("AWWWW MAN");
            Thing.transform.position=new Vector3(3f,-3f,0f);
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("AWWWW MAN");
            Thing.transform.position=new Vector3(-3f,3f,0f);
        }
        */
    }

    //new function goes here:

    void CheckHitObject()
    {
        Debug.Log("Entered Check Hit Object Function");

        //create a Ray from the mouse position to check and detect if anything was hit when clicked by the mouse
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        if(hit2D.collider !=null)
        {
            Debug.Log(hit2D.collider.name +"Was clicked");

            objSelected = hit2D.transform.gameObject;
        }
    }

    //function to drop object selected
    void DropObject()
    {
        //use a loop to check through the list of snap  points and if the positionss are close enough to snap to the point on the list
        for(int i=0; i<snapPoints.Length; i++)
        {
            //check the distance between the selected object and the snap point
            if(Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position)   < snapSensitivity)
            {
                //if distance is les than the snap sensitivity change gameobject location
                objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y , snapPoints[i].transform.position.z -0.1f);

            }
        }
        objSelected = null;
    }

    //write code to drag the game object and follow the mouse position
    //Drag function
    void DragObject()
    {
            //fixed value for th eoffset from the camera
            objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }
}

