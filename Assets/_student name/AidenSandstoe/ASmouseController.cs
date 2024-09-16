using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SearchService;
using UnityEngine;

public class ASmouseController : MonoBehaviour
{
    public GameObject card;

    public GameObject objSelected = null;


    public GameObject[] snapPoints;

    public float snapSensitivity = 2.0f;

    public float clipplaneOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //display a debug racy where moust is taking effect
        Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(newRay.origin, newRay.direction*25, Color.green);
        



        //code for getting mouse click
        if(Input.GetMouseButtonDown(0))
        {
            CheckHitObject();
          //  Debug.Log("Mouse button pressed");
        
        }

        //code for releasing the mouse
        if(Input.GetMouseButtonUp(0) && objSelected !=null)
        {
            Debug.Log("Mouse Button is released");
        //drop the object
            DropObject();
        
        }
        //coode for dragging with the mouse
    if(Input.GetMouseButton(0) && objSelected !=null)
{
    Debug.Log("Mouse Button is Being Held");
    // dragging object
    DragObject();
}


   /*     if(Input.GetKeyDown(KeyCode.Space))
        {
            card.transform.position=new Vector3(3f,3f,0f);
            Debug.Log("X Pressed");
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("X Unpressed");
            card.transform.position=new Vector3(-3f,-3f,0f);

        }
        */
    }
    //new functio goes here;
    void CheckHitObject()
    {
        Debug.Log("Entered Check Hit Object");
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        //create a Ray from the mouse position 
        if(hit2D.collider !=null)
        {
            Debug.Log(hit2D.collider.name + "Was clicked");
        
            objSelected = hit2D.transform.gameObject;

            
        }
 
    }

    //functio to drop object seleceted
    void DropObject()
    {
        for(int i=0; i<snapPoints.Length; i++)
        {

            if(Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position )  < snapSensitivity)
            {

                objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z -0.1f  );


            }
        }
        objSelected = null;

    }
    // write code to drag the game object amd follow the mouse position
    //Drag function
    void DragObject()
    {
        //fixed value for  the offset from the camera
        objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));


    }

}
