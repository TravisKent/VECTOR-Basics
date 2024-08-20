using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text player01Score;
    public Text player02Score;

    [SerializeField]
    public int numbPlayer01Score;
    [SerializeField]
    public int numbPlayer02Score;
    // Start is called before the first frame update
    void Start()
    {
        //Game
        player01Score.text = numbPlayer01Score.ToString();
        player02Score.text = numbPlayer02Score.ToString();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPointsPlayer01(int value)
    {
        numbPlayer01Score = numbPlayer01Score+value;
        //update player score
        player01Score.text = numbPlayer01Score.ToString();
    }
    public void SubtractPointsPlayer01(int value)
    {
        numbPlayer01Score = numbPlayer01Score - value;
        //update player score
        player01Score.text = numbPlayer01Score.ToString();
    }

    public void AddPointsPlayer02(int value)
    {
        numbPlayer02Score = numbPlayer02Score + value;
        //update player score
        player02Score.text = numbPlayer02Score.ToString();
    }
    public void SubtractPointsPlayer02(int value)
    {
        numbPlayer02Score = numbPlayer02Score - value;
        //update player score
        player02Score.text = numbPlayer02Score.ToString();
    }
}
