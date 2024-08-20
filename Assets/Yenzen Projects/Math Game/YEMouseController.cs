using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEMouseController : MonoBehaviour
{

/*
Code example based off of video from https://www.youtube.com/watch?v=1xb26bGCH2k
*/

GameObject objSelected = null;

public GameObject[] snapPoints;

private float snapSensitivity = 1.25f;

public float clipplaneOffset;

void Update()
{
    Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    Debug.DrawRay(newRay.origin, newRay.direction * 20, Color.green);

    if(Input.GetMouseButtonDown(0))
    {
        CheckHitObject();
    }
    if(Input.GetMouseButton(0)  && objSelected !=null)
    {
        DragObject();
    }
    if(Input.GetMouseButtonUp(0)  && objSelected !=null)
    {
        DropObject();
    }
}


void CheckHitObject()
{
    RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
/*
    if(hit2D.collider !=null)
    {
        objSelected = hit2D.transform.gameObject;
    }
    */
     if(hit2D.collider !=null)
        {
            //check object tag
            if(hit2D.collider.tag == "dice")
            {
                //effect the dice
                Debug.Log(hit2D.collider.name +" was clicked");
                hit2D.collider.GetComponent<DiceControl>().ChangeAnimationState(0); 
            }
             else if(hit2D.collider.tag == "diceV2")
            {
                //effect the dice
                Debug.Log(hit2D.collider.name +" was clicked");
                hit2D.collider.GetComponent<DiceControlVERSION2>().ChangeAnimationState(0); 
            }
            else if(hit2D.collider.tag == "NoMove")
             {
                //Do nothing
             }
            else
            {
                objSelected = hit2D.transform.gameObject;
            }

        }
}
void DragObject()
{
    objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10f));

}

void DropObject()
{
    for(int i=0; i<snapPoints.Length; i++)
    {
        if(Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position ) < snapSensitivity)
        {
            objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y,snapPoints[i].transform.position.z -0.1f );
        }
    }
    objSelected = null;
}
}