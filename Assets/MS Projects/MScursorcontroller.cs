using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MScursorcontroller : MonoBehaviour
{
    public GameObject PlayerOneCursor;
    GameObject objSelected = null;

    public GameObject[] snapPoints;
    public float SnapSenstivity = 2.0f;

    public float clipplaneOffset;
 
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        
        Ray newRay = Camera.main.ScreenPointToRay(PlayerOneCursor.transform.position);
        Debug.DrawRay(newRay.origin, newRay.direction * 20, Color.green);
        Vector3 betterRay = PlayerOneCursor.transform.position- new Vector3(0f, 0f, +20f);
        
        Ray ray1 = new Ray(betterRay, PlayerOneCursor.transform.forward);
        Debug.DrawRay(ray1.origin, ray1.direction * 40, Color.blue);

        Ray ray3 = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray3.origin, ray3.direction *20, Color.red);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed");
            CheckHitObject();

        }
        if(Input.GetKey(KeyCode.Space) && objSelected !=null)
        {
            DragObject();
        }
        if(Input.GetKeyUp(KeyCode.Space) && objSelected !=null)
        {
            DropObject();
        }
    }

    void CheckHitObject()
    {
        Vector3 betterRay = PlayerOneCursor.transform.position- new Vector3(0f, 0f, +20f);
        Ray ray1 = new Ray(betterRay, PlayerOneCursor.transform.forward);
        Debug.DrawRay(ray1.origin, ray1.direction * 40, Color.blue );
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray1);
/*
        if(hit2D.collider !=null)
        {
            Debug.Log("something was hit");
            objSelected = hit2D.transform.gameObject;
        }
        else
        {
            Debug.Log("nothing was hit");
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
            else
            {
                objSelected = hit2D.transform.gameObject;
            }

        }
         else
        {
            Debug.Log("nothing was hit");
        }
    }

    void DragObject()
    {
        objSelected.transform.position=new Vector3(PlayerOneCursor.transform.position.x, PlayerOneCursor.transform.position.y, 0f);
    }

    void DropObject()
    {
        for(int i=0; i<snapPoints.Length; i++)
        {
            if(Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position ) < SnapSenstivity)
            {
                objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z -0.1f );
            }
        }
        objSelected = null;
    }
}
