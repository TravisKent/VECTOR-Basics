using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FLO_barrelcontroller_1 : MonoBehaviour
{
     public bool joystickactivated;
     Vector2 inputAxis;
    
    public bool keysActivated = false;
    public bool mouseActivated = false;
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
            //rotate left
            if(Input.GetKey(KeyCode.A))
            {

                myRotation.z = Mathf.Clamp(myRotation.z +rotateSpeed*Time.deltaTime, 0f, 180f);

                barrel.transform.rotation = Quaternion.Euler(myRotation);

            }
            //rotate right
            if(Input.GetKey(KeyCode.D))
            {
                myRotation.z = Mathf.Clamp(myRotation.z - rotateSpeed*Time.deltaTime, 0f, 180f);

                barrel.transform.rotation = Quaternion.Euler(myRotation);
            }
        }

        if(joystickactivated)
        {
            inputAxis.x = Input.GetAxisRaw("Horizontal1");
            inputAxis.y = Input.GetAxisRaw("Vertical1");
            //rotate left
            if(inputAxis.x <-0.5)
            {

                myRotation.z = Mathf.Clamp(myRotation.z +rotateSpeed*Time.deltaTime, 0f, 180f);

                barrel.transform.rotation = Quaternion.Euler(myRotation);

            }
            //rotate right
            if(inputAxis.x >0.5)
            {
                myRotation.z = Mathf.Clamp(myRotation.z - rotateSpeed*Time.deltaTime, 0f, 180f);

                barrel.transform.rotation = Quaternion.Euler(myRotation);
            }
        }
    }
}
