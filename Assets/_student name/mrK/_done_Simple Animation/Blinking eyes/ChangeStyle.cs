using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStyle : MonoBehaviour
{

    public Animator tkAnimator;
    public int machineState=0;
    public int machineLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            machineState++;
            if(machineState > machineLimit)
            {
                machineState =0;
            }

            tkAnimator.SetInteger("machineState", machineState);

        }
        
    }
}
