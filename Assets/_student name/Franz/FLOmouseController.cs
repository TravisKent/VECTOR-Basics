using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLOmouseController : MonoBehaviour
{

    public TKplaySFX mySFX;
    //public GameObject card;
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
        Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(newRay.origin, newRay.direction*25, Color.green);

        if(Input.GetMouseButtonDown(0))
        {
             Debug.Log("Mouse Button Pressed");
             CheckHitObject();
        }
        if(Input.GetMouseButtonUp(0) && objSelected !=null)
        {
            Debug.Log("Mouse Button is released");
            DropObject();
            mySFX.PlayMySFX();
        }
        
        if(Input.GetMouseButton(0) && objSelected !=null)
        {
            Debug.Log("Mouse Button is being Held");
            DragObject();
        }



 
    }



    void CheckHitObject()
    {
     Debug.Log("Entered Check Hit Object function");

     RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main. ScreenPointToRay(Input.mousePosition));
     if(hit2D.collider !=null)
     {
          Debug.Log(hit2D.collider.name +"Was clicked");

          objSelected = hit2D.transform.gameObject;
     }
    }

    void DropObject()
    {
        for(int i=0; i<snapPoints.Length; i++)
        {
            if(Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position)   < snapSensitivity)
            {
                 objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z -0.1f );
                 
            }
        }
          objSelected = null;
    }

    void DragObject()
    {
          objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    } 

    
}


