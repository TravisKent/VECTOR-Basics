using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEmousecontroller : MonoBehaviour
{

    GameObject objSelected = null;

    public GameObject[] SnapPoints;

    private float snapSensitivity = 2.0f;
    public float clipplaneOffset;

   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(newRay.origin, newRay.direction * 20, Color.green);

        if(Input.GetMouseButtonDown(0))
        {
            CheckHitObject();
        }
        if(Input.GetMouseButton(0) && objSelected !=null)
        {
            DragObject();
        }
        if(Input.GetMouseButtonUp(0) && objSelected !=null)
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
            if(hit2D.collider.tag == "dice")
            {
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
                Debug.Log("something was hit");
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

            objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

    }
    void DropObject()
    {
        for(int i=0; i<SnapPoints.Length; i++)
        {
            if(Vector3.Distance(SnapPoints[i].transform.position, objSelected.transform.position) < snapSensitivity)
            {
            objSelected.transform.position = new Vector3(SnapPoints[i].transform.position.x,SnapPoints[i].transform.position.y, SnapPoints[i].transform.position.z -0.1f);
            }
        }
        objSelected = null;
    }
   
}


 //eof