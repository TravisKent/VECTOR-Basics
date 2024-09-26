using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatebarrle : MonoBehaviour
{
    public bool keysActivatied;
    public bool mouseActivated;
    public GameObject barrle;
    public float rotateSpeed = 5;


    private Vector3 myRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(keysActivatied)
        {
            //rotate left
            if(Input.GetKey(KeyCode.A))
            {

                myRotation.z=Mathf.Clamp(myRotation.z+rotateSpeed*Time.deltaTime, 0f, 180);

                barrle.transform.rotation=Quaternion.Euler(myRotation);
            }
            //rotation right
            if(Input.GetKey(KeyCode))
        }
    
    }
}
