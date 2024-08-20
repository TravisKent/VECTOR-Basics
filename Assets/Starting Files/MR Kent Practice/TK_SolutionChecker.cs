using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_SolutionChecker : MonoBehaviour
{
    public int spot1Value;
    public int spot2Value;
    public int spot3Value;
    public int spot4Value;
    public CheckValueInside Spot1, Spot2, Spot3, Spot4;

    public GameObject[] solutionFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        solutionFlag[0].SetActive(false);
        solutionFlag[1].SetActive(false);

        spot1Value = Spot1.ValueInside;
        spot2Value = Spot2.ValueInside;
        spot3Value = Spot3.ValueInside;
        spot4Value = Spot4.ValueInside;
        //spot 2 is the minus sign (-1) or the plus sign (+1) ... check this first to see which operation to do
        if(Spot2.ValueInside == +1)
        {
            //Check if the numbers added together are correct
            if(  (spot1Value + spot3Value) == spot4Value )
            {
                solutionFlag[0].SetActive(false);
                solutionFlag[1].SetActive(true);
            }
            else
            {
                solutionFlag[0].SetActive(true);
                solutionFlag[1].SetActive(false);
            }
        }
        else if(Spot2.ValueInside == -1)
        {
            //check if the number subtacted together are correct
             if(  (spot1Value - spot3Value) == spot4Value  )
            {
                solutionFlag[0].SetActive(false);
                solutionFlag[1].SetActive(true);
            }
            else
            {
                solutionFlag[0].SetActive(true);
                solutionFlag[1].SetActive(false);
            }
        }
        else
        {
            Debug.Log("you have an error for the sign value");

        }
    }
}
