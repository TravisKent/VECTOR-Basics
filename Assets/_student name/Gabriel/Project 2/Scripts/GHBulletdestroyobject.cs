using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GHBulletDestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name +" : was hit");
        Destroy(col.gameObject);
        //TODO Later
        //Create and instantiate some explosion effect
        //Destroy Bullet
        Destroy(gameObject);
    }
}
