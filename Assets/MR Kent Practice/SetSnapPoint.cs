using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSnapPoint : MonoBehaviour
{
    public bool PlayerSnapPoint, MoveableObjectSnapPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter2D(Collider2D other)
   {
        if(PlayerSnapPoint && other.tag=="Player")
        {
            Debug.Log("Ontrigger Enter activated");
            other.gameObject.GetComponent<MoveWhenClicked>().snappoint= transform;
        }
        if(MoveableObjectSnapPoint && other.tag=="Movable")
        {
            Debug.Log("Ontrigger Enter activated");
            other.gameObject.GetComponent<MoveWhenClicked>().snappoint= transform;
        }
   }

   void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Ontrigger EXIT activated");
        other.gameObject.GetComponent<MoveWhenClicked>().snappoint= null;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(PlayerSnapPoint && other.tag=="Player")
        {
            Debug.Log("Ontrigger Enter activated");
            other.gameObject.GetComponent<MoveWhenClicked>().snappoint= transform;
        }
        if(MoveableObjectSnapPoint && other.tag=="Movable")
        {
            Debug.Log("Ontrigger Enter activated");
            other.gameObject.GetComponent<MoveWhenClicked>().snappoint= transform;
        }
    }
}
