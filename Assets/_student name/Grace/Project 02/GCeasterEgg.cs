using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCeasterEgg : MonoBehaviour
{
    public Animator myAnimator;

    public bool L1;
    public bool L2;
    public bool L3;
    public bool L4;
    public bool L5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.G))
       {
        Debug.Log("G was pressed");
        L1 = true;
       } 

       if(Input.GetKeyDown(KeyCode.R) )
       {
        Debug.Log("r was pressed");
        if(L1==true)
        {
            L2 = true;
        }
        else
        {
            L1 = false;
            L3 = false;
            L2 = false;
            L4 = false;           
            L5 = false;
            Debug.Log("EE reset");
        }
        
       }
      

       if(Input.GetKeyDown(KeyCode.A) )
       {
        Debug.Log("a was pressed");
        if(L1==true && L2==true)
        {
            L3 = true;
        }
        else
        {
            L1 = false;
            L3 = false;
            L2 = false;
            L4 = false;           
            L5 = false;
            Debug.Log("EE reset");
        }
       
       }
       if(Input.GetKeyDown(KeyCode.C) )
       {
            Debug.Log("c was pressed");
            if(L1==true && L2==true && L3==true)
            {
                L4 = true;
            }
            else
            {
                L1 = false;
                L3 = false;
                L2 = false;
                L4 = false;           
                L5 = false;
                Debug.Log("EE reset");
            }
       }
       if(Input.GetKeyDown(KeyCode.E) )
       {
            Debug.Log("e was pressed");
            if( L1==true && L2==true && L3==true && L4==true )
            {
                L5 = true;
                myAnimator.SetBool("Cd", true);
            }
            else
            {
                L1 = false;
                L3 = false;
                L2 = false;
                L4 = false;           
                L5 = false;
                Debug.Log("EE reset");
            }

       }

 
      
      
    }
}
