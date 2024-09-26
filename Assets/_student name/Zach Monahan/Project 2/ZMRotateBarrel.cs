using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZMRotateBarrel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        public bool keysActivated;
        public bool mouseActivated;
        public GameObject barrel;
        public float rotateSpeed = 5;


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
            if(Input.GetKey(KeyCode .A))
            {

                myRotation.z = Math.Clamp(myRotation.z +rotateSpeed*Time.deltaTime, 0f, 180);

                barrel.transform.rotation =Quaternion.Euler(myRotation);



            }
            //rotate right
            if(Input.GetKey)KeyCode.D))
            {

                myRotation.z = Mathf.Clamp(myRotation.z -rotateSpeed*Time.deltaTime, 0f, 180);


                barrel.transform.rotation = Quaternion.Euler(myRotation);

            }


        }


    }



            }


        
    }
}
