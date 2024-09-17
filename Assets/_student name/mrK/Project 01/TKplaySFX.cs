using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKplaySFX : MonoBehaviour
{
    public AudioSource mySFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space ))
        {
            PlayMySFX();
        }
    }

    public void PlayMySFX()
    {
        mySFX.Play();
    }
}
