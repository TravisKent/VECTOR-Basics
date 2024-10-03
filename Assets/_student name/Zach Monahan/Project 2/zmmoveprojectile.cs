using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zmmoveprojectile : MonoBehaviour
{

    public Rigidbody2D rb;
    public float launchVelocity=10;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
       // rb.AddRelativeForce( new Vector3(launchVelocity, 0f,0f);
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
