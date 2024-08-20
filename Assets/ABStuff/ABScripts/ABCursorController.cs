using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABCursorController : MonoBehaviour
{
/*
Code example based off of video from https://www.youtube.com/watch?v=1xb26bGCH2k
*/
public bool player01, player02;
public GameObject PlayerOneCursor;

public GameObject objSelected = null;
public GameObject[] iSnapPoints;
public GameObject[] tSnapPoints;
private float snapSensitivity = 0.75f;
public float clipplaneOffset;
// Update is called once per frame
void Update()
{
/*
Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
Debug.DrawRay(transform.position, forward, Color.green);
*/
//draw a ray
Ray newRay = Camera.main.ScreenPointToRay(PlayerOneCursor.transform.position);
Debug.DrawRay(newRay.origin, newRay.direction * 20, Color.green);
Vector3 betterRay = PlayerOneCursor.transform.position- new Vector3(0f, 0f, +20f);
Ray ray1 = new Ray(betterRay, PlayerOneCursor.transform.forward);
Debug.DrawRay(ray1.origin, ray1.direction * 40, Color.blue );
Ray ray3 = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
Debug.DrawRay(ray3.origin, ray3.direction * 20, Color.red );
    if(player01)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        Debug.Log("Spacebar pressed");
        //check if obhect is clicked on
        CheckHitObject();
        }
        if(Input.GetKey(KeyCode.Space) && objSelected !=null)
        {
        //drag an object
        DragObject();
        }
        if(Input.GetKeyUp(KeyCode.Space) && objSelected !=null)
        {
        //drop the object
        DropObject();
        }
    }
   else if(player02)
    {
        if(Input.GetKeyDown(KeyCode.Quote))
        {
        Debug.Log("Quote pressed");
        //check if obhect is clicked on
        CheckHitObject();
        }
        if(Input.GetKey(KeyCode.Quote) && objSelected !=null)
        {
        //drag an object
        DragObject();
        }
        if(Input.GetKeyUp(KeyCode.Quote) && objSelected !=null)
        {
        //drop the object
        DropObject();
        }
    }
}
void CheckHitObject()
    {
        
        //create a ray from the mouse position and detect what is hit.
        Vector3 betterRay = PlayerOneCursor.transform.position- new Vector3(0f, 0f, +20f);
        Ray ray1 = new Ray(betterRay, PlayerOneCursor.transform.forward);
        Debug.DrawRay(ray1.origin, ray1.direction * 40, Color.blue );
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray1);

        if(hit2D.collider !=null)
        {
            //check object tag
            if(hit2D.collider.tag == "dice")
            {
                //effect the dice
                Debug.Log(hit2D.collider.name +" was clicked");
                hit2D.collider.GetComponent<ABDiceControl>().ChangeAnimationState(0); 
            }
            else
            {
                objSelected = hit2D.transform.gameObject;
            }

        }
    }
void DragObject()
{
// objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.nearClipPlane+clipplaneOffset));
// objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(PlayerOneCursor.transform.position.x,PlayerOneCursor.transform.position.y, 10f));
objSelected.transform.position = new Vector3(PlayerOneCursor.transform.position.x, PlayerOneCursor.transform.position.y, 0f);
}
void DropObject()
    {
       if(objSelected.tag == "Play")
       {

            //use a loop to check through the listed snap points and if the positions are close enough snap to the point in the list
            for(int i=0; i<iSnapPoints.Length; i++)
            {
                //check distance between selected object and the snap point
                if(Vector3.Distance(iSnapPoints[i].transform.position, objSelected.transform.position ) < snapSensitivity)
                {
                
                    objSelected.transform.position = new Vector3(iSnapPoints[i].transform.position.x, iSnapPoints[i].transform.position.y, iSnapPoints[i].transform.position.z -0.1f );
                    
                }
            }
            objSelected = null;
        }
        else if(objSelected.tag == "Tokens")
        {

            //use a loop to check through the listed snap points and if the positions are close enough snap to the point in the list
            for(int i=0; i<tSnapPoints.Length; i++)
            {
                //check distance between selected object and the snap point
                if(Vector3.Distance(tSnapPoints[i].transform.position, objSelected.transform.position ) < snapSensitivity)
                {
                
                    objSelected.transform.position = new Vector3(tSnapPoints[i].transform.position.x, tSnapPoints[i].transform.position.y, tSnapPoints[i].transform.position.z -0.1f );
                    
                }
            }
            objSelected = null;
        }

        objSelected = null;
    }

}

        