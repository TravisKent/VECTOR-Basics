using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenLoad : MonoBehaviour
{
    public GameObject levelLoader;
    public float counter = 5;
    public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
        levelLoader =  GameObject.Find("Load Main Menu");
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        if(counter <=0)
        {
            GameObject.Find("Level Loader").GetComponent<LevelManager>().LevelToLoad = LevelName;
            GameObject.Find("Level Loader").GetComponent<LevelManager>().LoadA(LevelName);
        }
    }
}
