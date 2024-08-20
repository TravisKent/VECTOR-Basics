using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckValueInside : MonoBehaviour
{
    public int ValueInside;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "number")
        {
            ValueInside=other.gameObject.GetComponent<PartValue>().myValue;
        }
        else
        {
            Debug.Log(other.name);
            Debug.Log("this item is not a number so don't count it's value");
        }
    }
}
