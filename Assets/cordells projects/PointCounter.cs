using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{

    public Text PlayerPoints;
    public float tokenDistance;
    public int points;
    public GameObject[] pointList; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         CheckForPoints();
         PlayerPoints.text = points.ToString();
       
    }


    void CheckForPoints()
    {
        points=0;
        pointList = GameObject.FindGameObjectsWithTag("token");
       foreach(GameObject objet in pointList)
        {
         
            if(Vector3.Distance(objet.transform.position, gameObject.transform.position ) <=tokenDistance)
            {
                points = points +1;
            }
        }
    }
}
