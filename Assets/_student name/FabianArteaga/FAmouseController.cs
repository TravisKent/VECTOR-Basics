using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FAmouseController : MonoBehaviour
{
    public TKplaySFX mySFX;
    public GameObject card;
    public GameObject objSelected = null;
    
    //list of game objects that will be used as snap points
    public GameObject[] snapPoints;
    //variable to be used as a radial distance check for the snap points
    public float snapSensitivity = 2.0f;

    //variable that can be usued for teh z distance offset
    public float cliplaneOffset; 

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
       
        //code for getting left mouse button click
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Button Pressed");
            CheckHitObject();
        }
        //code for releasing the mouse
        if(Input.GetMouseButtonUp(0) && objSelected !=null)
        {
            Debug.Log("Mouse Button is released");
            //drop  the object
            DropObject();
             mySFX.PlayMySFX();
        }
        
        //code for dragging with the mouse
        if(Input.GetMouseButton(0) && objSelected !=null)
        {
            Debug.Log("MOuse button is being Held");
            //dragging object
            DragObject();
        }


        //comment out old code
        /*
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space Pressed");
            card.transform.position = new Vector3(3f,3f, 0f);
            }
            

            
            if(Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("W Pressed");
                card.transform.position = new Vector3(-3f,-3f, 0f);
            }
            //check if mouse is pressed
            */
    }


    //new function goes here:
    void CheckHitObject()
    {
        Debug.Log("Entered Check Hit Object function");

        //creat a Ray from the mouse position to check and detect if anything was hit when clicked
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        if(hit2D.collider !=null)
        {
            Debug.Log(hit2D.collider.name +"Was clicked");

            objSelected = hit2D.transform.gameObject;
        }
    }

    //Function to drop bojected selected
    void DropObject()
    {
        //use a loop to check through the list of snap points and if the position are close enough to snap to the point on the list
        for(int i=0; i<snapPoints.Length; i++)
        {
            //check the distance between the selected objects and the snap point
            if(UnityEngine.Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position)  < snapSensitivity)
            {
                    //if distance is less than the snap sensivity change gameobject location.
                    objSelected.transform.position = new UnityEngine.Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z -0.1f);

            }
        }

        objSelected = null;
    }
    
    //write code to drag the game object and follow the mouse position
    //Dreag function
    void DragObject()
    {
            //fixed value for the offset from the camera
            objSelected.transform.position = Camera.main.ScreenToWorldPoint(new UnityEngine.Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }
}