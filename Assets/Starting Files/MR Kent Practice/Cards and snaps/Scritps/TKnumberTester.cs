using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  TMPro;
public class TKnumberTester : MonoBehaviour
{
    public TextMeshProUGUI numDisplay;
    public float numberTest;
    public int intNumberTest;
    public int placevalue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numDisplay.text = intNumberTest.ToString();
        /*
        //placevalue calculations
          var ones = Math.floor(num % 10),
            tens = Math.floor(num/10 % 10),
            hundreds = Math.floor(num/100 % 10),
            thousands = Math.floor(num/1000 % 10),
            tenThousands = Math.floor(num / 10000 % 10),
            hundredThousands = Math.floor(num / 100000 % 10),
            millions = Math.floor(num / 1000000 % 10),
            tenMillions = Math.floor(num / 10000000 % 10),
            hundredMillions = Math.floor(num / 100000000 % 10);
            
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(Mathf.FloorToInt((intNumberTest/10)%placevalue));
        }

        */
    }


    public void AddValue(int value)
    {
        intNumberTest +=value;
    }
    public void SubtractValue(int value)
    {
        intNumberTest -=value;
    }
}
