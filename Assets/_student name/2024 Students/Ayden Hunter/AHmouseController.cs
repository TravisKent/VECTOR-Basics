using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AHmouseController : MonoBehaviour
{

    public TKplaySFX mySFX;
    public GameObject Card;
    public GameObject objSelected = null;

    //list of game objects that will be used as snap points
    public GameObject[] snapPoints;
    //variable to be used as a radial distance check for the snap points
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
        //display a debug ray where mouse is taking effect
        Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(newRay.origin, newRay.direction*25, Color.green);


         //code for getting left mouse button click
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button pressed");
            CheckHitObject();
        }
        //code for releasing the mouse      
        if(Input.GetMouseButtonUp(0) && objSelected !=null)
        {
            Debug.Log("Mouse button released");
            // drop the object
            DropObject();
            mySFX.PlayMySFX();
        }
        

        //code for dragging with the mouse
        if(Input.GetMouseButton(0) && objSelected !=null)
        {
            Debug.Log("Mouse button is being held");
            //dragging object
            DragObject();

        }
    





//comment out old code
/*
         if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Woah that's cool");
            Card.transform.position = new Vector3(3f,3f,0f);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Yippie");
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            Card.transform.position = new Vector3(0f,0f,0f);
        }

        */
    }


    //new function goes here:
    void CheckHitObject()
    {
        Debug.Log("Entered Check Hit Object function");

        //create a Ray from the moiuse position to check and detect if anything was hit when clicked by the mouse
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
        //use a loop to check through the list of snap points and if the positions are close enough to snap to the point on the list
        for(int i=0; i<snapPoints.Length; i++)
        {
            //check the distance between the selected object and the snap point
            if(Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position)  < snapSensitivity)
            {
                //if distance is less than the snap sensitivity change gameobject location.
                objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z -0.1f);

            }
        }


        objSelected = null;
    }

    //write code to drag the game object and follow the mouse position
    //Drag function
    void DragObject()
    {
        //fixed value for the offset from the camera
        objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

}
//10:11