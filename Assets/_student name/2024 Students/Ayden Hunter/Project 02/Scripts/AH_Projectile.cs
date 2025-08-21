using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AH_Projectile : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;
    float rangeMax = 1.5f;

    void Start()
    {
        //Fetch the Rigid body from the GameObject with his script attatched
        m_Rigidbody = GetComponent<Rigidbody>();

        m_Rigidbody.AddForce(new Vector3(Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax)) * m_Thrust );
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Add some force");
            //Apply a force to this Rigidbody in random direction
            m_Rigidbody.AddForce(new Vector3(Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax)) * m_Thrust);
        }
    }






}
