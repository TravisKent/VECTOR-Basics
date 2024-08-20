using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string LevelToLoad;
    void Start()
    {
        Debug.Log("LoadSceneA");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            LoadA(LevelToLoad);
        }
    }

    public void LoadA(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }

}
