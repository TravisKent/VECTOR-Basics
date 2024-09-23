using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class GHprojectile : MonoBehaviour
{
   Rigidbody m_Rigidbody;
   public float m_Thrust = 20f;
   float rangeMax = 1.5f;

   void Start()
  {
    //fetch teh rigidbody from the gameobject with this script attached 
    m_Rigidbody = GetComponent<Rigidbody>();

    m_Rigidbody.AddForce(new Vector3(Random.Range(-1*rangeMax,rangeMax), Random.Range(-1*rangeMax,rangeMax),Random.Range(-1*rangeMax,rangeMax) ) * m_Thrust );
  } 

  void Update()
  {
    if(Input.GetKeyDown(KeyCode.Space))
    {
        Debug.Log("Add some force");
        //apply a force to this rigidbody in random direction
        m_Rigidbody.AddForce(new Vector3(Random.Range(-1*rangeMax,rangeMax),Random.Range(-1*rangeMax,rangeMax),Random.Range(-1*rangeMax,rangeMax)) * m_Thrust );
    }
  }

}
