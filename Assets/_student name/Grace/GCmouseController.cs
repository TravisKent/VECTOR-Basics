using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCmouseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE PRESSED");
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("SPACE released");
        }

    }
}
