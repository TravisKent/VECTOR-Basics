using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDestroyed : MonoBehaviour
{
    public GameObject[] bossParts;
    public int  bossPartsDistroyed = 0;
    public GameObject winSCreen;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bossPartsDistroyed = 0;
        foreach (var item in bossParts)
        {
            if(item.activeSelf)
            {
                //do nothing;
            }
            else if(item.activeSelf == false)
            {
                bossPartsDistroyed++;
            }
            
        }
        if(bossPartsDistroyed >= (bossParts.Length-1))
        {
            Debug.Log("Boss has been Destryed, turn on win banner and load main menu");
            Instantiate(winSCreen,spawnPoint.position, spawnPoint.rotation );
            Destroy(gameObject);
        }
    }
}
