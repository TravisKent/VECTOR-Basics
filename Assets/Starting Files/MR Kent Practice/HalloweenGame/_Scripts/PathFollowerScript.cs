using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowerScript : MonoBehaviour
{


	public PathEditorScript PathToFollow;

	public int CurrentWaypointID=0;
	public float speed;
	public float reachDistance = 1.0f;
	public float rotationSpeed = 5.0f;
	public bool flipImage;
	public string pathName;
	public bool spriteInChildObject=false;
	public SpriteRenderer childSprite;

	Vector3 lastPosition;
	Vector3 currentPosition;

	// Use this for initialization
	void Start () {
		lastPosition = transform.position;
	//	pathName = PathToFollow.name.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		if(CurrentWaypointID >= PathToFollow.path_Objs.Count ||CurrentWaypointID < 0)
		{
			CurrentWaypointID = 0;
		}

		float distance  = Vector3.Distance(PathToFollow.path_Objs[CurrentWaypointID].position, transform.position);
		transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_Objs[CurrentWaypointID].position, Time.deltaTime *speed);
		
		
		if(flipImage)
		{
			Vector3 MovementDirection = PathToFollow.path_Objs[CurrentWaypointID].position-transform.position;
			if(MovementDirection.x >=0)
			{
				if(spriteInChildObject==false)
				{
					gameObject.GetComponent<SpriteRenderer>().flipX = true;
				}
				else
				{
					childSprite.flipX = true;
				}
			}
			else{
				if(spriteInChildObject==false)
				{
					gameObject.GetComponent<SpriteRenderer>().flipX = false;
				}
				else
				{
					childSprite.flipX = false;
				}

			}
		}
		//var rotation  = Quaternion.LookRotation(PathToFollow.path_Objs[CurrentWaypointID].position - transform.position);
		//
		//rotation.x = 90;
		//rotation.y = 0;
		//rotation.z=0;
		//transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed *Time.deltaTime);

		Vector3	lookPos = PathToFollow.path_Objs[CurrentWaypointID].position - transform.position;
         float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
       //  transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		//transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed *Time.deltaTime);







		if(distance <= reachDistance)
		{
			CurrentWaypointID++;
		}

		if(CurrentWaypointID >= PathToFollow.path_Objs.Count)
		{
			CurrentWaypointID = 0;
		}

	}

}
