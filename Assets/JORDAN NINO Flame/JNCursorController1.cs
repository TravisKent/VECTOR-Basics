using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JNCursorController1 : MonoBehaviour
{
        // Start is called before the first frame update
        /*
    Code example based off of video from https://www.youtube.com/watch?v=1xb26bGCH2k
    */
    public bool player01, player02;
    public GameObject PlayerOneCursor;
    public SpriteRenderer playerSprite;
    public Sprite grabSprite;
    public Sprite pointSprite;
    
    GameObject objSelected = null;

    public GameObject[] snapPoints;
    public float snapSensitivity = 2.0f;

    public float clipplaneOffset;
    void Update()
    {
        /*
        Vector3 forward = transform. TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        */

        Ray newRay = Camera.main.ScreenPointToRay(PlayerOneCursor.transform.position);
        Debug.DrawRay(newRay.origin, newRay.direction * 20, Color.green);

        Vector3 betterRay = PlayerOneCursor.transform.position- new Vector3(0f, 0f,+20f);
        Ray ray1 = new Ray(betterRay, PlayerOneCursor.transform.forward); 
        Debug.DrawRay(ray1.origin, ray1.direction * 40, Color.blue );
        Ray ray3 = new Ray(Camera.main.transform.position, Camera.main.transform.forward); 
        Debug.DrawRay(ray3.origin, ray3.direction * 20, Color.red );

        if(player01)
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            { Debug.Log("Spacebar pressed"); 
                //check if obhect is clicked on 
                CheckHitObject(); 
            } 
            if(Input.GetKey(KeyCode.Space)  && objSelected !=null) 
            { 
                //drag an object 
                DragObject(); 
            } 
            if(Input.GetKeyUp(KeyCode.Space)  && objSelected !=null) 
            { 
                //drop the object
                DropObject(); 
            }
        }


    else if (player02)
     {
            if(Input.GetKeyDown(KeyCode.Quote)) 
            { Debug.Log("Quote pressed"); 
                //check if obhect is clicked on 
                CheckHitObject(); 
            } 
            if(Input.GetKey(KeyCode.Quote)  && objSelected !=null) 
            { 
                //drag an object 
                DragObject(); 
            } 
            if(Input.GetKeyUp(KeyCode.Quote)  && objSelected !=null) 
            { 
                //drop the object
                DropObject(); 
            }
        }

    }

    void CheckHitObject() 
    {
        Vector3 betterRay = PlayerOneCursor.transform.position- new Vector3(0f, 0f, +20f); 
        Ray ray1 = new Ray(betterRay, PlayerOneCursor.transform.forward); 
        Debug.DrawRay(ray1.origin, ray1.direction * 40, Color.blue );
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray1); 
        //RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(PlayerOneCursor.transform.position));
        if(hit2D.collider !=null)
        { 
            if(hit2D.collider.tag == "dice")
            {
                //effect the dice
                Debug.Log(hit2D.collider.name +" was clicked");
                hit2D.collider.GetComponent<JNDiceControl>().ChangeAnimationState(0); 
            }
            else{
            Debug.Log("something was hit");
            objSelected = hit2D.transform.gameObject; 
            playerSprite.sprite = grabSprite;
            }
        } 
        else 
        { 
            Debug.Log("nothing was hit");
        }
    }

void DragObject()
 {  // objSelected.transform.position =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane+clipplaneOffset));
    // objSelected.transform.position =  Camera.main.ScreenToWorldPoint(new Vector3(PlayerOneCursor.transform.position.x, PlayerOneCursor.transform.position.y, 10f)); 
    objSelected.transform.position =  new Vector3(PlayerOneCursor.transform.position.x, PlayerOneCursor.transform.position.y, 0f); 
}

void DropObject()
 { 
    for(int i=0; i<snapPoints.Length; i++)
     { //check distance between selected object and the snap point
     if(Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position ) < snapSensitivity)
      {
         objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z -0.1f );
          } 
        } 
        objSelected = null;
         playerSprite.sprite = pointSprite;

 }

 
}


