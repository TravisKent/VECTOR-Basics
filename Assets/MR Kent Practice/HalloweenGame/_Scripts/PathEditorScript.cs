using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEditorScript : MonoBehaviour
{
   

	public Color rayColor = Color.red;
	public List<Transform> path_Objs = new List<Transform>();
	public float wireMarkerSize = 0.3f;

	Transform[] theArray;
	[Header("StarSettings")]
	public float StarInnerRadious; 
	public float StarOuterRadious;
	public bool makeStar;
	[Header("RegularPolySettings")]
	[Range(3,50)]
	public int numberOfPolyPoints;
	public float polyRadious;
	public bool makePoly;


	void OnDrawGizmos()
	{
		Gizmos.color= rayColor;
		if(makeStar)
		{
			MakeAStar();
		}
		else if(makePoly)
		{
			MakeAPolygon(numberOfPolyPoints);
		}
		theArray = GetComponentsInChildren<Transform>();
		path_Objs.Clear();

		foreach( Transform path_obj in theArray)
		{
			if(path_obj!= this.transform)
			{
				path_Objs.Add(path_obj);
			}
		}

		for(int i=0; i < path_Objs.Count; i++)
		{
			Vector3 position = path_Objs[i].position;
			if(i==0)
			{
				Gizmos.DrawWireCube(position,new Vector3(wireMarkerSize, wireMarkerSize, wireMarkerSize)*2f);

			}

			if(i>0)
			{
				Vector3 previous = path_Objs[i-1].position;
				Gizmos.DrawLine(previous, position);
				Gizmos.DrawWireSphere(position, wireMarkerSize);

			}
			if(makeStar)
			{
				PositionStarPoints( StarInnerRadious,  StarOuterRadious);
			}
			else if(makePoly)
			{
				PositionPolyPoints( numberOfPolyPoints,polyRadious);
			}
			makeStar = false;
			makePoly = false;

			Gizmos.DrawLine(path_Objs[path_Objs.Count-1].position, path_Objs[0].position);
		}




	}	

	void MakeAPolygon(int max)
	{
		if(max <3)
		{
			max = 3;
		}
		
		Debug.Log(theArray.Length);
		for (int i = theArray.Length; i <= max; i++) 
		{
			//add more nodes
			GameObject go = new GameObject("Node");
			go.transform.parent = gameObject.transform;
		}
	}
	void PositionPolyPoints(int numberOfPolyPoints,float radious)
	{
		float[] angle;
		angle = new float[numberOfPolyPoints];
		for (int j = 0; j < numberOfPolyPoints; j++) 
		{
			angle[j] = j*360f/(numberOfPolyPoints*1f);
			path_Objs[j].position = 
				new Vector3(radious*Mathf.Cos( (angle[j]*Mathf.PI)/180 ),radious*Mathf.Sin( (angle[j]*Mathf.PI)/180 ),0);
		}
	}


	void MakeAStar()
	{
		int max = 10;
		Debug.Log(theArray.Length);
		for (int i = theArray.Length; i <= max; i++) 
		{
			//add more nodes
			GameObject go = new GameObject("Node");
			go.transform.parent = gameObject.transform;
		}
	}
	void PositionStarPoints(float r_i, float r_o)
	{
		float[] angle;
		angle = new float[10];
		for (int k = 0; k < 10; k++) {
			angle[k] = 0;
		}
		for (int j = 0; j < 10; j++) 
		{
			angle[j] = j*360f/10f;
			Debug.Log("Angle["+j.ToString()+"]="+angle[j]);
			float temp = j%2;
			Debug.Log("is it odd or even?"+temp.ToString());
			if(j%2 ==0)
			{
				//even
				path_Objs[j].position = 
				new Vector3(r_o*Mathf.Cos( (angle[j]*Mathf.PI)/180 ),r_o*Mathf.Sin( (angle[j]*Mathf.PI)/180 ),0);
			}
			else
			{
				//odd
				path_Objs[j].position = 
				new Vector3(r_i*Mathf.Cos( (angle[j]*Mathf.PI)/180 ),r_i*Mathf.Sin( (angle[j]*Mathf.PI)/180 ),0);
			}
		}

	}

}
