using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    //public float bulletSpeed;
    public Vector3 lastPosition;
    public Vector3 directionMoving;
    public GameObject imageToRotate;
    //public float slerpRotationSpeed;
     //private Quaternion targetRotation;
     private float count = .3f;
    public Rigidbody2D rb;

    //VFX
    public SpawnAfterDestruction sAd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void FixedUpdate()
    {
        count -=Time.deltaTime;
        if(count<0)
        {
            directionMoving = transform.position - lastPosition;
            lastPosition = transform.position;
            
            directionMoving = directionMoving.normalized;
            float rise, run;
            rise = (directionMoving.y);
            run = (directionMoving.x);
            float myVal = Mathf.Atan2(rise, run)*180/3.14159f;
            Vector3 rotationToAdd = new Vector3(0, 0, myVal);
           // Debug.Log(rotationToAdd);
            
            transform.eulerAngles=rotationToAdd;
            //imageToRotate.transform.eulerAngles=rotationToAdd; 
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Halloween Object")
        {
            Destroy(other.gameObject);
            sAd.SpawnObj();
        }
        if(other.tag =="Ground")
        {
            //Destroy(other.gameObject);
            sAd.SpawnObj();
        }
    
    }
}
