using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESbulletDestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name +": was hit");
        if(col.tag == "NonDestruct")
        {
            //do nothing
        }
        else 
        {
            Destroy(col.gameObject);
            //todo later
            //create and instantiate some explosion effect
        }
        
        //destroy bullet
        Destroy(gameObject);
    }
}
