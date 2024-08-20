using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JNmouseController : MonoBehaviour
{
    /*
        Code example based off of video from https://www.youtube.com/watch?v=1xb26bGCH2k

    */

    //variable for game object clicked/selected
    GameObject objSelected = null;

    //List of game objects that will be used as snap points
    public GameObject[] snapPoints; 
   //variable to be used as a radial distance check for the snap points
    public float snapSensitivity = 2.0f;
    
    //variable that can be used for the z distance offset
    public float clipplaneOffset;

    // Update is called once per frame
    void Update()
    {

        //display as a debug ray where things are taking effect
        Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(newRay.origin, newRay.direction * 20, Color.green);

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
            if(hit2D.collider.tag == "dice")
            {
                //effect the dice
                Debug.Log(hit2D.collider.name +" was clicked");
                hit2D.collider.GetComponent<JNDiceControl>().ChangeAnimationState(0); 
            }
            else
            {
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
        //use a loop to check through the listed snap points and if the positions are close enough snap to the point in the list
        for(int i=0; i<snapPoints.Length; i++)
        {
            //check distance between selected object and the snap point
            if(Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position ) < snapSensitivity)
            {
                objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z -0.1f );
            }
        }
        objSelected = null;
    }
}
