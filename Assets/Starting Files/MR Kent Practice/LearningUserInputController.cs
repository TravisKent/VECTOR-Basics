using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class LearningUserInputController : MonoBehaviour
{
    Camera m_Camera;
     
   
    // Start is called before the first frame update
    void Awake()
    {
        m_Camera = Camera.main;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse mouse = Mouse.current;
       if (Input.GetMouseButtonDown(0))
       {
           RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
            if(hit.collider != null)
            {
                //Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
            
               GameObject goHit = hit.collider.gameObject;
              // Debug.Log(goHit.name +" was hit yo!");
                if(goHit.tag == "Movable")
                {
                    goHit.GetComponent<MoveWhenClicked>().ActivateMoveOption();
                }
                else if(goHit.tag == "Player")
                {
                    goHit.GetComponent<MoveWhenClicked>().ActivateMoveOption();
                }
            } 
       }

       if (Input.GetMouseButtonUp(0))
       {
           RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
            if(hit.collider != null)
            {
               // Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
            
               GameObject goHit = hit.collider.gameObject;
                if(goHit.tag == "Movable")
                {
                // Debug.Log(goHit.name +" was hit yo! when you let up the mouse");
                goHit.GetComponent<MoveWhenClicked>().DeActivateMoveOption();
                goHit.GetComponent<MoveWhenClicked>().OhhhSNAP();
                }
                else if(goHit.tag == "Player")
                {
                // Debug.Log(goHit.name +" was hit yo! when you let up the mouse");
                goHit.GetComponent<MoveWhenClicked>().DeActivateMoveOption();
                goHit.GetComponent<MoveWhenClicked>().OhhhSNAP();
                }
            } 
             
       }
    }

    /*
    void OnMouseDown()
    {
        Debug.Log("Mouse has been clicked");
    }
    */
    
}
