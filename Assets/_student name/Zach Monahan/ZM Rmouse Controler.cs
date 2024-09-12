





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZMRmouseControler : MonoBehaviour
{
    
  public GameObject objSelected=null; 
  public GameObject card; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Bar Was Pressed");
            card.transform.position = new Vector3(3f, 3f, 0f);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space Bar Was released ");
           
        }
    }
}

