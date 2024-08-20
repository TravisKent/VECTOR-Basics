using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKJoystickCursor : MonoBehaviour
{
    public bool player01, player02;


    Vector2 InputAxes;
    public float MoveSpeed = 10f;
    public Rigidbody2D theRB;

    //XYZ positions that are used to limit the cursor movement horizontally and vertically
    public Transform bottomLeftLimit, topRightLimit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput ();
        theRB.velocity = new Vector2(InputAxes.x, InputAxes.y)*MoveSpeed;
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y),  transform.position.z);

        
    }

    void GetInput() 
    {
        if(player01)
        {
            InputAxes.x = Input.GetAxisRaw ("Horizontal1");
            InputAxes.y = Input.GetAxisRaw ("Vertical1");
        }
        else if(player02)
        {
            InputAxes.x = Input.GetAxisRaw ("Horizontal2");
            InputAxes.y = Input.GetAxisRaw ("Vertical2");
        }
    }
}
