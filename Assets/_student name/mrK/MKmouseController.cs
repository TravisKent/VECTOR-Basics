using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MKmouseController : MonoBehaviour
{

    public GameObject card;
    public GameObject objSelected = null;
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
          if(Input.GetMouseButtonUp(0))
          {
               Debug.Log("Mouse Button is released");
          }


          //code for dragging with the mouse
          if(Input.GetMouseButton(0))
          {
               Debug.Log("Mouse Button is being Held");
          }



//comment out old code
/*
       if(Input.GetKeyDown(KeyCode.Space))
       {
            Debug.Log("SPACE BAR WAS PRESSED");
            card.transform.position = new Vector3(3f, 3f, 0f);

       }
       if(Input.GetKeyDown(KeyCode.W))
       {
            Debug.Log("SPACE BAR WAS PRESSED");
            card.transform.position = new Vector3(3f, 4f, 0f);

       }
       if(Input.GetKeyDown(KeyCode.S))
       {
            Debug.Log("SPACE BAR WAS PRESSED");
            card.transform.position = new Vector3(3f, 2f, 0f);

       }

       if(Input.GetKeyDown(KeyCode.A))
       {
            Debug.Log("SPACE BAR WAS PRESSED");
            card.transform.position = new Vector3(2f, 3f, 0f);

       }
       if(Input.GetKeyDown(KeyCode.D))
       {
            Debug.Log("SPACE BAR WAS PRESSED");
            card.transform.position = new Vector3(4f, 3f, 0f);

       }

       if(Input.GetKeyUp(KeyCode.Space))
       {
        Debug.Log("Space bar was released");
       }

       */
    }


    //new function goes here:
    void CheckHitObject()
    {
     Debug.Log("Entered Check Hit Object function");

     //create a Ray from the mouse position to check and detect if anything was hit when clicked by the mouse
     RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
     if(hit2D.collider !=null)
     {
          Debug.Log(hit2D.collider.name +"Was clicked");

          objSelected = hit2D.transform.gameObject;
     }
    }

}
