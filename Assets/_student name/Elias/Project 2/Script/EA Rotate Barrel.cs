using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBarrel : MonoBehaviour
{
    //
    public bool JoystickActivated;
    Vector2 inputAxes;
    public bool keysActivated;
public bool mouseActivated;
public GameObject barrel;
public float rotateSpeed = 5f;

private Vector3 myRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(keysActivated)
     {
        //Rotate left
        if(Input.GetKey(KeyCode.A))
        {
            myRotation.z = Mathf.Clamp(myRotation.z +rotateSpeed*Time.deltaTime, 0f, 180f);
            barrel.transform.rotation = Quaternion.Euler(myRotation);
        }
        //rotate right
        if(Input.GetKey(KeyCode.D))
        {
            myRotation.z = Mathf.Clamp(myRotation.z -rotateSpeed*Time.deltaTime, 0f, 180f);
            barrel.transform.rotation = Quaternion.Euler(myRotation);  
        }
     }   

        if(JoystickActivated)
        {
            inputAxes.x = Input.GetAxisRaw ("Horizontal1");
            inputAxes.y = Input.GetAxisRaw ("Vertical1");
            if(inputAxes.x < -0.5)
            {
                 myRotation.z = Mathf.Clamp(myRotation.z +rotateSpeed*Time.deltaTime, 0f, 180f);
                barrel.transform.rotation = Quaternion.Euler(myRotation);
            }
            if(inputAxes.x > 0.5)
            {
                 myRotation.z = Mathf.Clamp(myRotation.z -rotateSpeed*Time.deltaTime, 0f, 180f);
                barrel.transform.rotation = Quaternion.Euler(myRotation);
            }
        }

    }
}
