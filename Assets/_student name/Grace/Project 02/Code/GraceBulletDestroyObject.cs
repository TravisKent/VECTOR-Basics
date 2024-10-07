using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraceBulletDestroyObjects : MonoBehaviour
{
    public bool hit1stTarget = false;
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
        Debug.Log(col.gameObject.name+" : was hit");
       // Destroy(col.gameObject);
       if(hit1stTarget == false)
       {
        hit1stTarget = true;
        Destroy(col.gameObject);
       }
        Destroy(gameObject);
    }
}
