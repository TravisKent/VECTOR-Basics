using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPmouseController : MonoBehaviour
{
    public GameObject thing;
    public GameObject objectSelected = null;

    //List of objects using snap points
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
        //Ray code
        Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(newRay.origin, newRay.direction*25, Color.cyan);

        //getting click
          if(Input.GetMouseButtonDown(0))
          {
             Debug.Log("Mouse 0 Pressed");
             CheckHitObject();
          }
         //release
         if(Input.GetMouseButtonUp(0) && objectSelected !=null)
         {
                Debug.Log("Mouse 0 realed");
                //drop the object
                DropObject();

         }
         
         // dragging  with mouse
          if(Input.GetMouseButton(0) && objectSelected !=null)
          {
                 Debug.Log("Mouse Button is being Held");
                //dragging object
                DragObject();
          }

            /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("AdhesiveHam");
            thing.transform.position=new Vector3(3f,3f,0f);
        }
         if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("AdhesiveHam");
            thing.transform.position=new Vector3(3f,4f,0f);
        }
         if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("AdhesiveHam");
            thing.transform.position=new Vector3(2f,3f,0f);
        }
         if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("AdhesiveHam");
            thing.transform.position=new Vector3(3f,2f,0f);
        }






        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Victory");
        }
        */
    }


    //new funtion


void CheckHitObject()
{
  Debug.Log("object hit");
  RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
  if(hit2D.collider !=null)
 
  {
     Debug.Log(hit2D.collider.name + "Was Clicked");

     objectSelected = hit2D.transform.gameObject;
  }
}




//function to drop

void DropObject()
{
    //snap to closest snap point
    for(int i =0;  i<snapPoints.Length; i++)
    {
        if(Vector3.Distance(snapPoints[i].transform.position, objectSelected.transform.position) < snapSensitivity)
        {
            //if distance less than snap to location
            objectSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z -0.1f);
        

        }

    }
     
        objectSelected = null;
}


            //code for drag and follow mouse
            //drag funtion
            void DragObject()
        {
            //fixed value of offset camera
            objectSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        }



}
