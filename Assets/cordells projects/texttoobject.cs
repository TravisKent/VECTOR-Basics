using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texttoobject : MonoBehaviour
 {  //Get the screen position of a physical object in world space (i.e. The Robot)
public static Vector3 GetScreenPosition(Transform transform,Canvas canvas,Camera cam)
{
    Vector3 pos;
    float width = canvas.GetComponent<RectTransform> ().sizeDelta.x;
    float height = canvas.GetComponent<RectTransform > ().sizeDelta.y;
    float x = Camera.main.WorldToScreenPoint (transform.position).x / Screen.width;
    float y = Camera.main.WorldToScreenPoint (transform.position).y / Screen.height;
    pos = new Vector3 (width * x - width / 2, y * height - height / 2); 
    return pos;    
}

}