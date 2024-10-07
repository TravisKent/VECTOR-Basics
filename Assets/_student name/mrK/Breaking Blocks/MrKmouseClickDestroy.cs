using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrKmouseClickDestroy : MonoBehaviour
{
    

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
              // Debug.Log("Mouse Button Pressed");
               CheckHitObject();
          }
          //code for releasing the mouse
          if(Input.GetMouseButtonUp(0) )
          {
             //  Debug.Log("Mouse Button is released");
              
          }




    }


    //new function goes here:
    void CheckHitObject()
    {
          Debug.Log("Entered Check Hit Object function");
/*
          //create a Ray from the mouse position to check and detect if anything was hit when clicked by the mouse
          RaycastHit hit3D = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), transform.TransformDirection(Vector3.forward), 20f,  out hit3D, Mathf.Infinity);
          if(hit3D.collider !=null)
          {
               Debug.Log(hit3D.collider.name +"Was clicked");
            //Check Tag
            if(hit3D.collider.tag =="destructable")
            {
                Debug.Log("tag matches");
                hit3D.collider.GetComponent<SpawnAfterDestruction>().SpawnObj();
            }
               
          }
          */

          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit3D;
            if (Physics.Raycast(ray, out hit3D, 25))
            {
                Debug.Log(hit3D.transform.name);
                Debug.Log("hit3D");
                if(hit3D.collider.tag =="destructable")
                {
                    Debug.Log("tag matches");
                    hit3D.collider.transform.parent.GetComponent<SpawnAfterDestruction>().SpawnObj();
                    //hit3D.collider.GetComponent<SpawnAfterDestruction>().SpawnObj();
                }
            }
         
    }

   


}
