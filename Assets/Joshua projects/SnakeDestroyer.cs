using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "heart")
        {
            Debug.Log(other.gameObject.name + " : "  + "is gettting et by snake");
            Destroy(other.gameObject);
        }
        {
            if(other.tag == "number")
        {
            Debug.Log(other.gameObject.name + " : "  + "is gettting et by snake");
            Destroy(other.gameObject);
        }
        }
    }
}
