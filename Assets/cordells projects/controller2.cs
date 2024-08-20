using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller2 : MonoBehaviour
{
public GameObject PlayertwoCursor;
  GameObject objSelected=null;
  public GameObject[]snapPoints;
  private float snapSensitivity=2.0f;
  public float clipplaneOffset;
  void Update()
  {
      Ray newRay=Camera.main.ScreenPointToRay(PlayertwoCursor.transform.position);
      Debug.DrawRay(newRay.origin, newRay.direction *20, Color.green);
      Vector3 betterRay=PlayertwoCursor.transform.position-new Vector3(0f, 0f, +20f);
      Ray ray1=new Ray(betterRay, PlayertwoCursor.transform.forward);
      Debug.DrawRay(ray1.origin, ray1.direction*40,Color.blue);
      Ray ray3=new Ray(Camera.main.transform.position,Camera.main.transform.forward);
      if(Input.GetKeyDown(KeyCode.Return))
      {
          Debug.Log("key code.Return pressed");
          CheckHitObject();
      }
      if(Input.GetKey(KeyCode.Return)&& objSelected!=null)
      {
          DragObject();
      }
      if(Input.GetKeyUp(KeyCode.Return)&& objSelected!=null)
      {
          DropObject();
      }
     
  }
  void CheckHitObject()
  {
      Vector3 betterRay=PlayertwoCursor.transform.position-new Vector3(0f, 0f,+29f);
      Ray ray1=new Ray(betterRay,PlayertwoCursor.transform.forward);
      Debug.DrawRay(ray1.origin,ray1.direction*40,Color.blue);
      RaycastHit2D hit2D=Physics2D.GetRayIntersection(ray1);
      if(hit2D.collider!=null)
      {
          Debug.Log("somethig was hit");
          objSelected=hit2D.transform.gameObject;
      }
      else
      {
          Debug.Log("nothing was hit");
      }
  }
  void DragObject()
  {
     objSelected.transform.position=new Vector3(PlayertwoCursor.transform.position.x, PlayertwoCursor.transform.position.y,0f);
  }
  void DropObject()
  {
      for(int i=0; i<snapPoints.Length; i++)
      {
          if(Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position)<snapSensitivity)
          {
              objSelected.transform.position=new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z -0.1f);
          }
      }
      objSelected=null;
  }
}