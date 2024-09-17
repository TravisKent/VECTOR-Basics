using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MrKbarrelControl_1 : MonoBehaviour
{
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
            //if keys activated do this code

            //rotate left
            if(Input.GetKey(KeyCode.A))
            {
                myRotation.z = Mathf.Clamp(myRotation.z +rotateSpeed*Time.deltaTime, 0f, 180f);
                barrel.transform.rotation = Quaternion.Euler(myRotation);
            }

            //rotate right
            if(Input.GetKey(KeyCode.D))
            {
                myRotation.z = Mathf.Clamp( myRotation.z - rotateSpeed*Time.deltaTime,0f,180f);
                barrel.transform.rotation = Quaternion.Euler(myRotation);
            }

        }




    }
}
