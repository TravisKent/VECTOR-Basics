using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESprojectile : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;
    float rangeMax = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //fetch the ridgidbody from the gameobject with this script attatched
        m_Rigidbody  = GetComponent<Rigidbody>();

        m_Rigidbody.AddForce(new Vector3(Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax)) * m_Thrust );
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Add some force");
            //apply a force to this ridgidbody in random direction
            m_Rigidbody.AddForce(new Vector3(Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax) ) * m_Thrust );
        }
    }
}
