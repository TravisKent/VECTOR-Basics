using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TKChangeState : MonoBehaviour
{
    public Animator myAnimator;
    public int machineState=0;
    public int maxMachineState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            machineState = machineState+1;
            //reset the state back to zero if it passes the limit
            if(machineState>maxMachineState)
            {
                machineState =0;
            }
            myAnimator.SetInteger("ChangeState", machineState);

        }
        
    }
}
