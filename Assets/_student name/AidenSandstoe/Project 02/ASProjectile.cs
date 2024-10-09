using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASProjectile : MonoBehaviour
{

    public GameObject projectile;
    public Transform firePointPosition;
   public Transform firePointRotation;
    public float shotDelay;
    float myTimer;
    
   Rigidbody m_RigidBody;
   public float m_Thrust = 20f;
   float rangeMax = 1.5f;

    void Start()
    {
        //fetch the rigidbody from the GameObject with this script attached
        m_RigidBody = GetComponent<Rigidbody>();

        m_RigidBody.AddForce(new Vector3(Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax))* m_Thrust );
     }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Add Some Force");
            //Apply a force to this rigidbody in random direction
            m_RigidBody.AddForce(new Vector3(Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax))  * m_Thrust );
        }
        
    }
}
