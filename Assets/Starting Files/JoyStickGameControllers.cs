using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class JoyStickGameControllers : MonoBehaviour
{
   
    /*
        Code example based off of video from https://www.youtube.com/watch?v=1xb26bGCH2k

    */

    public KeyCode p1button01, p1button02;
    //public KeyCode p1Up, p1Down, p1Left, p1Right, p1button01, p1button02, p1button03, p1button04;
   // public KeyCode p2Up, p2Down, p2Left, p2Right, p2button01, p2button02, p2button03, p2button04;

    public GameObject PlayerOneCursor;
    GameObject objSelected = null;

    public GameObject[] snapPoints; 
    public float snapSensitivity = 2.0f;
    public bool player1, player2;
    
    public float clipplaneOffset;

    public GameObject particalEffect;

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        */

        //draw a ray
        /*
       Ray newRay = Camera.main.ScreenPointToRay(PlayerOneCursor.transform.position);
       Debug.DrawRay(newRay.origin, newRay.direction * 20, Color.green);

        Vector3 betterRay = PlayerOneCursor.transform.position- new Vector3(0f, 0f, +20f);
       Ray ray1 = new Ray(betterRay, PlayerOneCursor.transform.forward);
        Debug.DrawRay(ray1.origin, ray1.direction * 40, Color.blue );

        Ray ray3 = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray3.origin, ray3.direction * 20, Color.red );
        */
        if(player1)
        {

            Vector3 betterRay = PlayerOneCursor.transform.position- new Vector3(0f, 0f, +20f);
        Ray ray1 = new Ray(betterRay, PlayerOneCursor.transform.forward);
        Debug.DrawRay(ray1.origin, ray1.direction * 40, Color.blue );
            if(Input.GetKeyDown(p1button01))
            {
                Debug.Log(p1button01+" pressed");
                //check if obhect is clicked on
                CheckHitObject();
            }
            if(Input.GetKey(p1button01)  && objSelected !=null)
            {
                //drag an object
               // DragObject();
            }
            if(Input.GetKeyUp(p1button01)  && objSelected !=null)
            {
                //drop the object
               // DropObject();
            }
        }
       /* else if(player2)
        {
            if(Input.GetKeyDown(p2button01))
            {
                Debug.Log(p2button01+ " pressed");
                //check if obhect is clicked on
                CheckHitObject();
            }
            if(Input.GetKey(p2button01)  && objSelected !=null)
            {
                //drag an object
                DragObject();
            }
            if(Input.GetKeyUp(p2button01)  && objSelected !=null)
            {
                //drop the object
                DropObject();
            }
        }*/
        

    }


    void CheckHitObject()
    {

        Vector3 betterRay = PlayerOneCursor.transform.position- new Vector3(0f, 0f, +20f);
        Ray ray1 = new Ray(betterRay, PlayerOneCursor.transform.forward);
        Debug.DrawRay(ray1.origin, ray1.direction * 40, Color.blue );
         RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray1);
        //RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(PlayerOneCursor.transform.position));
       
       
       

        //check what the ray hit
        
        if(hit2D.collider !=null)
        {
           //check object tag
            if(hit2D.collider.tag == "destructable")
            {
                //effect the dice
                Debug.Log(hit2D.collider.name +" was clicked");
                objSelected = hit2D.transform.gameObject;
                Vector3 spLocation = objSelected.transform.position;
                Instantiate(particalEffect,spLocation, quaternion.identity );
                Destroy(objSelected);
                
            }             
            else if(hit2D.collider.tag == "NoMove")
            {
            //Do nothing
            }
            else if(hit2D.collider.tag == "Halloween Object")
            {
            //Do nothing
            }
            else if(hit2D.collider.tag == "LevelButton")
            {
                //
                GameObject.Find("Level Loader").GetComponent<LevelManager>().LevelToLoad = hit2D.collider.GetComponent<LevelButton>().LevelToLoadName;
                GameObject.Find("Level Loader").GetComponent<LevelManager>().LoadA(hit2D.collider.GetComponent<LevelButton>().LevelToLoadName);
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
      // objSelected.transform.position =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane+clipplaneOffset));
       // objSelected.transform.position =  Camera.main.ScreenToWorldPoint(new Vector3(PlayerOneCursor.transform.position.x, PlayerOneCursor.transform.position.y, 10f));
        objSelected.transform.position =  new Vector3(PlayerOneCursor.transform.position.x, PlayerOneCursor.transform.position.y, 0f);
    }

    void DropObject()
    {
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
