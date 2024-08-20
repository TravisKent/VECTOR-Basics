using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVectorMove2 : MonoBehaviour
{

    public Vector2 myDisplacementVector;
    public float mySpeedVariable;

    public GameObject ArrowPointingVector;
    Vector3 myScalar;

    public bool useMousePosition;
    public Vector3 location;
    float myMag;


    public GameObject DestinationMarker;
    public Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        This code will scale the arrow to make it point to were our guy will go
        */
        myScalar = new Vector3 (1f,1f,1f);
        if(useMousePosition)
        {
            Vector3 objectPos = Camera.main.WorldToScreenPoint(ArrowPointingVector.transform.position);
            location = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            Debug.Log(location);
            Vector3 dir = Input.mousePosition - objectPos;
            //dir.Normalize();
            myDisplacementVector = new Vector2(dir.x, dir.y);
            ArrowPointingVector.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(myDisplacementVector.y, myDisplacementVector.x) * Mathf.Rad2Deg);

            Vector3 Loc_dir = location - gameObject.transform.position;
            
            location  = new Vector3(Loc_dir.x, Loc_dir.y, 0f);
            //location  = new Vector3(location.x, location.y, 0f);
            myMag = location.magnitude;
            ArrowPointingVector.transform.localScale = myScalar*myMag;
        }
        else
        {
            ArrowPointingVector.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(myDisplacementVector.y, myDisplacementVector.x) * Mathf.Rad2Deg);
            myMag = myDisplacementVector.magnitude;
            ArrowPointingVector.transform.localScale = myScalar*myMag;
        }
        
        if(Input.GetKeyDown(KeyCode.Space ))
        {
            destination = location;
            Instantiate(DestinationMarker, destination, Quaternion.identity);
            /*
            This Code uses the displacement vector and the speed scalar to move 
            every time we press the spacebar 
            */
            /*
            if(useMousePosition)
            {
                transform.Translate(location * mySpeedVariable , Space.World);
            }
            else
            {
                transform.Translate(myDisplacementVector * mySpeedVariable , Space.World);
            }
            */
        }

        //Move the helm at a set speed to selected destination.
        float distance = (destination-transform.position).magnitude;
        if(distance< 0.5f)
        {
            //stop
        }
        else
        {
            transform.Translate(destination * mySpeedVariable*Time.deltaTime, Space.World);
        }
    }

}
