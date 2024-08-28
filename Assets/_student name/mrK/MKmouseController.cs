using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MKmouseController : MonoBehaviour
{

    public GameObject card;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
            Debug.Log("SPACE BAR WAS PRESSED");
            card.transform.position = new Vector3(3f, 3f, 0f);

       }
       if(Input.GetKeyDown(KeyCode.W))
       {
            Debug.Log("SPACE BAR WAS PRESSED");
            card.transform.position = new Vector3(3f, 4f, 0f);

       }
       if(Input.GetKeyDown(KeyCode.S))
       {
            Debug.Log("SPACE BAR WAS PRESSED");
            card.transform.position = new Vector3(3f, 2f, 0f);

       }

       if(Input.GetKeyDown(KeyCode.A))
       {
            Debug.Log("SPACE BAR WAS PRESSED");
            card.transform.position = new Vector3(2f, 3f, 0f);

       }
       if(Input.GetKeyDown(KeyCode.D))
       {
            Debug.Log("SPACE BAR WAS PRESSED");
            card.transform.position = new Vector3(4f, 3f, 0f);

       }

       if(Input.GetKeyUp(KeyCode.Space))
       {
        Debug.Log("Space bar was released");
       }
    }

}
