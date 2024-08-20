using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterTurretControl : MonoBehaviour
{
    public Transform myTarget;
    public float speed;
    public float turretRotationSpeed;
    public float turrertLeftRotationLimit;
    public float turrertRightRotationLimit;
    public GameObject turretBarrel;
    public GameObject projectile;
    public float projectilePower;

    public GameObject GunPointingVector;
    public Transform BarrelSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
         //Vector3 targetDirection = myTarget.position - transform.position;

         
            //Vector3 targetDirection =myTarget.position - transform.position;
            Vector3 targetDirection =myTarget.position - BarrelSpawnPoint.transform.position;
          //  Debug.Log(targetDirection);
           
            Vector2 myDisplacementVector = new Vector2(targetDirection.x, targetDirection.y);
            this.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(myDisplacementVector.y, myDisplacementVector.x) * Mathf.Rad2Deg);
             // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, Vector2.right, Color.red);
            
        /*

        // Determine which direction to rotate towards
        Vector3 targetDirection = myTarget.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
         //Vector2 newDirection = Vector2.RotateTowards(new Vector3(1,0,0), targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
        */
    }
        /*
        if(Input.GetKey(KeyCode.A) && (turretBarrel.transform.rotation.eulerAngles.z < turrertLeftRotationLimit))
        {
            //rotate the turret to the left
            //turretBarrel.transform.rotation = Quaternion.Euler(new Vector3(0,0,15f));
            RotateByDegrees(1f*turretRotationSpeed*Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D) && (turretBarrel.transform.rotation.eulerAngles.z > turrertRightRotationLimit))
        {
            //rotate the turret to the right
            RotateByDegrees(-1f*turretRotationSpeed*Time.deltaTime);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            GameObject bullet = Instantiate(projectile, turretBarrel.transform.position, turretBarrel.transform.rotation);
             //Debug. Break();

            bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3 (projectilePower, 0,0));

        }
        
        
    }

    void RotateByDegrees(float myVal)
    {
        Vector3 rotationToAdd = new Vector3(0, 0, myVal);
        turretBarrel.transform.Rotate(rotationToAdd);
    }

*/
 
    
}
