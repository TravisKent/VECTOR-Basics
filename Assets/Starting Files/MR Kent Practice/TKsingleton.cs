using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKsingleton : MonoBehaviour
{
     public int myval;
    private static TKsingleton _instance;

    public static TKsingleton Instance { get { return _instance; } }


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}
