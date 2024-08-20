using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceControlVERSION2 : MonoBehaviour
{
    
    Animator diceAnimator;

    public Transform spawnPoint;
    public int RangeEndLimit=7;
    public GameObject[] ObjectToSpawn;
    public int stateVal=-1;
    // Start is called before the first frame update
    void Start()
    {
        diceAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        diceAnimator.SetInteger("StateChoice", stateVal);
    }

    public void ChangeAnimationState(int myVal)
    {
        if(stateVal<0)
        {
            stateVal = 0;
            Debug.Log("state set to: " +stateVal);
        }
        else if(stateVal ==0)
        {
            myVal  = Random.Range(1,RangeEndLimit);
            Debug.Log("random number chosen: " +myVal);
            stateVal = myVal;
             Debug.Log("state set to: " +stateVal);
        }
        else if(stateVal>=1  )
        {
            stateVal = -1;
             Debug.Log("state set to: " +stateVal);
        }

        if(stateVal>0)
        {
            Instantiate(ObjectToSpawn[stateVal] , spawnPoint.position, spawnPoint.rotation);
        }
    }
}
