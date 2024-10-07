using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class GracebarrelControl_1 : MonoBehaviour
{
    public bool joySTickActivated;
    Vector2 InputAxes;
    public bool keysActivated;
    public bool  mouseActivated;
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
            if(Input.GetKey(KeyCode.A))
        {
            myRotation.z = Mathf.Clamp(myRotation.z +rotateSpeed*Time.deltaTime, 0f, 180f);
            barrel.transform.rotation = Quaternion.Euler(myRotation);
        }
            if(Input.GetKey(KeyCode.D))
            {
                myRotation.z=Mathf.Clamp(myRotation.z -rotateSpeed*Time.deltaTime, 0f, 180);
                barrel.transform.rotation = Quaternion.Euler(myRotation);
            }
                 if(joySTickActivated)
            {
                
                //InputAxes.x = Input.GetAxisRaw ("Horizontal1");
                //InputAxes.y = Input.GetAxisRaw ("Vertical1");
                InputAxes.x = Input.GetAxis ("Horizontal1");
                Debug.Log(InputAxes.x);
                InputAxes.y = Input.GetAxis ("Vertical1");
                if(InputAxes.x < -0.5 )
                {

                    myRotation.z = Mathf.Clamp(myRotation.z + rotateSpeed*Time.deltaTime, 0f, 180f);
                    barrel.transform.rotation = Quaternion.Euler(myRotation);

                }
                else if(InputAxes.x > 0.5 ) 
                {
                    myRotation.z = Mathf.Clamp(myRotation.z - rotateSpeed*Time.deltaTime, 0f, 180f);

                    barrel.transform.rotation = Quaternion.Euler(myRotation);
                }
            }
       
        }
    }
}
