using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MKmouseController : MonoBehaviour
{

   public  GameObject objSelected = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE PRESSED");
            objSelected.transform.position = new Vector3(3f,3f, 0f);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("SPACE released");
        }
        //check if mouse button is pressed
        if(Input.GetMouseButtonDown(0))
        {
            //check if obhect is clicked on
            CheckHitObject();
        }
        //check if mouse button is held down/dragging
       if(Input.GetMouseButton(0)  && objSelected !=null)
        {
            //drag an object
            DragObject();
        }
        //check if mouse button is released
        if(Input.GetMouseButtonUp(0)  && objSelected !=null)
        {
            //drop the object
            DropObject();
        }
        
    }


     void CheckHitObject()
    {
        
        //create a ray from the mouse position and detect what is hit.
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if(hit2D.collider !=null)
        {
            //check object tag
            if(hit2D.collider.tag == "Movable")
            {
                //effect the dice
                Debug.Log(hit2D.collider.name +" was clicked and is movable");
                objSelected = hit2D.transform.gameObject;
            }
            else if(hit2D.collider.tag == "NoMove")
             {
                //Do nothing
             }
            else
            {
                Debug.Log(hit2D.collider.name +" was clicked BUT IS NOT TAGGED");
                objSelected = hit2D.transform.gameObject;
            }

        }
    }

    void DragObject()
    {
        //fixed for the offset from the camera we want
      // objSelected.transform.position =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane+clipplaneOffset));
        objSelected.transform.position =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

    }

     void DropObject()
    {
       
        objSelected = null;
    }
}
