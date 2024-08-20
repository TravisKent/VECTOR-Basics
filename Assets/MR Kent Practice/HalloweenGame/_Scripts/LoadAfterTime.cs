using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAfterTime : MonoBehaviour
{
     public float lifetime;
     public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        lifetime -= Time.deltaTime;
        if(lifetime<=0)
        {
            Debug.Log("Time to load");
             GameObject.Find("Level Loader").GetComponent<LevelManager>().LevelToLoad = LevelName;
                GameObject.Find("Level Loader").GetComponent<LevelManager>().LoadA(LevelName);
           
        }
        
        //Destroy(gameObject, lifetime);
        

    }
}
