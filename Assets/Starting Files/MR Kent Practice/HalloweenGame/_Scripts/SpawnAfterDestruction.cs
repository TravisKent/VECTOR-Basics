using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAfterDestruction : MonoBehaviour
{
    public int points;
    public GameObject ObjectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObj()
    {
        Instantiate(ObjectToSpawn, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
}
