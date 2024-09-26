
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class JRmouseCoutroler : MonoBehaviour
{

    public GameObject Card;
    public GameObject objSelected =null;

         //list of game objects that will be used as snap points 
     public GameObject[] snapPoints;
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
        //code for getting left mouse button click
        if(Input.GetMouseButtonDown(0))
        {
           // Debug.Log("Mouse Button Pressed");
            CheckHitObject();
        }


        //code for releaqsing the mouse
        if(Input.GetMouseButtonUp(0) && (objSelected !=null) )
        {
            //  Debug.Log("Mouse Button is released"); 
             DropObject();
        }

        //code for dragging with the mouse
        if(Input.GetMouseButton(0) && (objSelected !=null))
        {
           // Debug.Log("Mouse Button is being Held"); 
             DragObject();
        }




    }  

    //new function goes here
    void CheckHitObject()
    {
        Debug.Log("Entered Check Hit Object function");

        //creat a Ray from the mouse position to check and detect if anything was hit when clicked by the mouse 
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        if(hit2D.collider !=null)        
        {
            Debug.Log(hit2D.collider.name +"Was clicked");

            objSelected = hit2D.transform.gameObject;
        }
    }
    //Function to drop object selected 
    void DropObject()
    {
        
        //use a loop to check though the list of snap points and if the position are close enough to snap on then list
        for(int i=0; i<snapPoints.Length; i++) 
        {
            if(Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position)  < snapSensitivity)
            {
                //if distance is less than the snap sensitivity change gameobject location
                objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x,snapPoints[i].transform.position.y,snapPoints[i].transform.position.z-0.1f);
            }
        }

        objSelected = null;



    }

    
    //write code to drag the game object follow the mouse position
    //Drag function
    void DragObject()

    {
        //fixed value for the offset from the camra
        objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }





}  


