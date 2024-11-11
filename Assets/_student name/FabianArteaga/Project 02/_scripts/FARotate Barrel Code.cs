using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBarrelCode : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust;
    float rangeMax = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();

        m_Rigidbody.AddForce(new Vector3(Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax)) * m_Thrust);
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Add some force");
            //Apply a force to this Rigidbody in random direction
            m_Rigidbody.AddForce(new Vector3(Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax, rangeMax), Random.Range (-1*rangeMax, rangeMax)) * m_Thrust);
        }
    }
}

