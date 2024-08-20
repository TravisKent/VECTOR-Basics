using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JoyStickDetecting : MonoBehaviour
{
    public TMP_Text controllerName;
    public TMP_Text verticalAxis;
    public TMP_Text horizontalAxis;
    public TMP_Text button00;
    public TMP_Text button01;
    public TMP_Text button02;
    public TMP_Text button03;
    // Start is called before the first frame update
    void Start()
    {
        string[] joysticknames = Input.GetJoystickNames();
        Debug.Log("number of joysticks connected is:"+joysticknames.Length.ToString());
        Debug.Log(joysticknames[0]);
        controllerName.text = joysticknames[0];
    }

    // Update is called once per frame
    void Update()
    {
        TK_ReadJoystick();
    }
    public void TK_ReadJoystick()
    {
        
        button00.text= Input.GetKey(KeyCode.Joystick1Button0).ToString() ;
        button01.text= Input.GetKey(KeyCode.Joystick1Button1).ToString() ;
        button02.text= Input.GetKey(KeyCode.Joystick1Button2).ToString() ;
        button03.text= Input.GetKey(KeyCode.Joystick1Button3).ToString() ;
        horizontalAxis.text = Input.GetAxisRaw("Horizontal1").ToString();
        verticalAxis.text = Input.GetAxisRaw("Vertical1").ToString();
    }
}
