using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWhenClicked : MonoBehaviour
{
    public bool MoveActivated;


     public Transform snappoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveActivated)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;

            transform.position = newPosition;
        }
    }

    public void ActivateMoveOption()
    {
        MoveActivated = true;
    }

    public void DeActivateMoveOption()
    {
        MoveActivated = false;
    }


    
    /*
     private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ontrigger Enter activated");
        snappoint = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        snappoint = null;
    }
    */
    
    public void OhhhSNAP()
    {
        //snap to the center point 
        if(snappoint != null)
        {
            transform.position = snappoint.position;
        }
    }
}
