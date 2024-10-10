using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASBulletDestroyObject : MonoBehaviour
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
        Debug.Log(col.gameObject.name +"  : was hit");    
        if(col.gameObject.tag == "LevelButton")
        {


        }
        else {
        Destroy(col.gameObject);
        //TODO Later
        //Create and Instantiate some explosion
        Destroy(gameObject);
        }
    }   
    
}
