using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAmouseController : MonoBehaviour
{

    public TKplaySFX mySFX;
   public  GameObject objSelected = null;
   public  GameObject Card;

   //snap points
   public GameObject[] snapPoints;
   //varible to be used as a radial distance check
   public float snapSensitivity = 2.0f;

   //varible that can be used for the z distanvce

   public float clipplaneOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //Display a dubug racy where mouse is rtaking effect
      Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
      Debug.DrawRay(newRay.origin, newRay.direction*25, Color.green);
      //Press Mouse Buttion
      if(Input.GetMouseButtonDown(0))
      {
        Debug.Log("Mouse Button is Pressed");
         CheckHitObject();
      }


      //let go of mouse button
      if(Input.GetMouseButtonUp(0)  && objSelected !=null)
      {
        Debug.Log("Mouse Button is Released");
        DropObject();
        
        mySFX.PlayMySFX();
      }


      //drag mouse buton
      if(Input.GetMouseButton(0)  && objSelected !=null)
      {
        Debug.Log("Mouse Button is being Held");
        DragObject();
      }
      
     /* 
      if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE PRESSED");
            objSelected.transform.position = new Vector3(3f,3f, 0f);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("SPACE released");
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W PRESSED");
            objSelected.transform.position = new Vector3(3f,6f, 0f);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("W released");
        }
         if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A PRESSED");
            objSelected.transform.position = new Vector3(1f,4f, 0f);
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("A released");
        }
         if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S PRESSED");
            objSelected.transform.position = new Vector3(3f,2f, 0f);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("S released");
        }
         if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D PRESSED");
            objSelected.transform.position = new Vector3(6f,4f, 0f);
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("D released");
        }
        */
    }


    // New code
    void CheckHitObject()
    {
    Debug.Log("Entered Check Hit Object function");
    RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
    if(hit2D.collider !=null)
    {
        Debug.Log(hit2D.collider.name + "Was Clicked");

        objSelected = hit2D.transform.gameObject;
    }

    }

    void DropObject()
    {
       //Loop to check throug list of snap points and if the psiton are close enough to snap
       for(int i=0; i<snapPoints.Length; i++)
       {
            //Chekc the distance between the sleclected onj and the sp
            if(Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position )  < snapSensitivity)
            {
                //if distance is less than the snap sensitivity chang game obj location
                objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z -0.1f );


            }
       }
       
        objSelected = null;
    }
// code for srag object and foolow mouse posiion // drag function
    void DragObject()
    {
        //fixed value for offsett camera
        objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }
}
