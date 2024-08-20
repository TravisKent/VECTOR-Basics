using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public float turretRotationSpeed;
    public float turrertLeftRotationLimit;
    public float turrertRightRotationLimit;
    public GameObject turretBarrel;
    public GameObject projectile;
    public float projectilePower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
